import { ChangeDetectorRef, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Company } from 'src/app/shared/model/company';
import { RawType } from 'src/app/shared/model/enums/rawType';
import { InternalDocumentData, InternalDocumentType } from 'src/app/shared/model/internalDocumentsData';
import { Raw } from 'src/app/shared/model/raw';
import { RawToSell } from 'src/app/shared/model/rawToSell';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';
import { RawService } from 'src/app/shared/services/raw-service/raw.service';
import { SellRawTableComponent } from '../../sell-raw-table/sell-raw-table.component';
import { InvoicesService } from 'src/app/shared/services/invoices-service/invoices.service';
import { IncomingInvoiceDTO } from 'src/app/shared/model/invoices/incomingInvoiceDTO';
import { InvoiceItem } from 'src/app/shared/model/invoices/invoiceItem';
import { Product } from 'src/app/shared/model/product';

@Component({
  selector: 'app-internal-documents-dialog',
  templateUrl: './internal-documents-dialog.component.html',
  styleUrls: ['./internal-documents-dialog.component.css']
})
export class InternalDocumentsDialogComponent implements OnInit {

  allDocumentType = InternalDocumentType;

  invoiceID : string = "";
  date : Date  = new Date() ;

  companies : Company[] = [];
  showCompany:boolean = true;
  selectedCompany : Company | undefined;

  newRaw:boolean = false;
  newRawType : string = "raw" ;
  selectedRaw: Raw | undefined;
  raws: Raw[] = [];
  bottles: Raw[] = [];
  caps: Raw[] = [];
  labels : Raw[] = [];
  
  singlePiceForm : FormGroup = new FormGroup({
    name:new FormControl(),
    singlePrice : new FormControl(),
    count: new FormControl(),
    unit:new FormControl("kom"),
    pdv: new FormControl(17)
  })

  rawsToSell : RawToSell[] | InvoiceItem[] =[];
  
  total_value_without_pdv : number = 0;
  total_value_of_pdv : number = 0;
  total_value_with_pdv: number = 0;

  constructor(
    public dialogRef: MatDialogRef<InternalDocumentsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: InternalDocumentData,
    private cd:ChangeDetectorRef,
    private companyService: CompanyService,
    private rawService: RawService,
    private invoicesService: InvoicesService
    ) { }

  ngOnInit(): void {
    
    if( this.data.isReadonly === false &&
      (this.data.documentType == InternalDocumentType.INCOMING_INVOICE || this.data.documentType == InternalDocumentType.INTERNAL_ISSUE_RAW)){
      this.updateAllRaws();
    }

    if(this.data.documentType == InternalDocumentType.INCOMING_INVOICE && this.data.isReadonly === false){
      this.companyService.getAllSupplierCompanies().subscribe(
        data =>{
          this.companies = data;
        }
      );
    }
    
    if(this.data.isReadonly){
      this.invoiceID = this.data.invoice!.invoiceID;
      this.date = this.data.invoice!.date;

      if(this.data.documentType === InternalDocumentType.INCOMING_INVOICE){
        this.companyService.getCompanyInfo(this.data.invoice!.supplierID).subscribe(
          data =>{
            this.selectedCompany = data;
          }
        );
      }

      this.rawsToSell = this.data.invoice!.items;
      this.updateTotalPrices();
    }
  }

  updateAllRaws(){
    this.rawService.getAllRaws().subscribe(
      data=>{
        data.forEach(x => {
          if( x.rawType== RawType.BOTTLE)
            this.bottles.push(x);
          else if( x.rawType== RawType.RAW)
            this.raws.push(x);
          else if( x.rawType== RawType.CAP)
            this.caps.push(x);
          else if( x.rawType== RawType.LABEL)
            this.labels.push(x);
        });
      }
    );
  }
  
  changeSelectedCompany(selectedCompany : Company){
    this.selectedCompany = selectedCompany;
  }

  changedSelectedRaw(){
    this.singlePiceForm.get('name')?.setValue(this.selectedRaw?.name);
    this.singlePiceForm.get('singlePrice')?.setValue(this.selectedRaw?.singlePrice);
    this.singlePiceForm.get('count')?.setValue(0);

  }
  
  changeSelectedProduct(product:Product|undefined)
  {
    if(product){
      this.singlePiceForm.get('name')?.setValue(product.name);
      this.singlePiceForm.get('singlePrice')?.setValue(product.singlePrice);
      this.singlePiceForm.get('count')?.setValue(0);
    }
    else{
      this.singlePiceForm.get('name')?.setValue("");
      this.singlePiceForm.get('singlePrice')?.setValue("");
      this.singlePiceForm.get('count')?.setValue(0);
    }
  }

  getRawType():RawType{
    if(this.newRawType === "raw")
      return RawType.RAW;
    else if( this.newRawType === "cap")
      return RawType.CAP;
    else if( this.newRawType === "label")
      return RawType.LABEL;
    return RawType.BOTTLE;
  }

  addNewPiceToList(){
    let value_out_pdv = this.singlePiceForm.get('singlePrice')?.value * this.singlePiceForm.get('count')?.value;
    let value_pdv = value_out_pdv * this.singlePiceForm.get('pdv')?.value / 100;
    let value_total = value_out_pdv + value_pdv;
    value_out_pdv = +value_out_pdv.toFixed(2);
    value_pdv = +value_pdv.toFixed(2);
    value_total = +value_total.toFixed(2);
    let newPice : RawToSell = {
      itemID: this.newRaw ? -1 : this.selectedRaw?.id! ,
      rawType: this.getRawType(),
      name: this.singlePiceForm.get('name')?.value,
      count: this.singlePiceForm.get('count')?.value,
      unit: this.singlePiceForm.get('unit')?.value,
      price_single: this.singlePiceForm.get('singlePrice')?.value,
      pdv: this.singlePiceForm.get('pdv')?.value,
      value_out_pdv: value_out_pdv,
      value_pdv: value_pdv,
      value_total: value_total
    };

    this.rawsToSell= [... this.rawsToSell,newPice];
    this.updateTotalPrices();
  }

  deleteRawToSell(rawToSellForDelete:RawToSell){
    this.rawsToSell = this.rawsToSell.filter(r => r != rawToSellForDelete);
    this.updateTotalPrices();
  }

  updateTotalPrices(){
    this.total_value_without_pdv =  0;
    this.total_value_of_pdv =  0;
    this.total_value_with_pdv=  0;

    this.rawsToSell.forEach(x =>{
      this.total_value_without_pdv += x.value_out_pdv;
      this.total_value_of_pdv += x.value_pdv;
      this.total_value_with_pdv += x.value_total;
    })
    this.total_value_without_pdv = +this.total_value_without_pdv.toFixed(2);
    this.total_value_of_pdv = +this.total_value_of_pdv.toFixed(2);
    this.total_value_with_pdv = +this.total_value_with_pdv.toFixed(2);
  }

  addNewInvoice(){
    if(this.data.documentType == InternalDocumentType.INCOMING_INVOICE){
      this.addNewIncomingInvoice();
    }
    
    if(this.data.documentType == InternalDocumentType.INTERNAL_ISSUE_RAW){
      this.addNewIssueRaw();
    }
  }

  addNewIncomingInvoice(){

    let newIncomingInvoice : IncomingInvoiceDTO ={
      invoiceID: this.invoiceID,
      date: this.date.toLocaleDateString('sv'),
      supplierID: this.selectedCompany!.id,
      invoiceItems: this.rawsToSell as RawToSell[],
      totalValueOfPdv: this.total_value_of_pdv,
      totalValueWithoutPdv: this.total_value_without_pdv,
      totalValue: this.total_value_with_pdv
    };

    this.invoicesService.addNewIncomingInvoice(newIncomingInvoice).subscribe(
      data=>{
        this.dialogRef.close("addedNewInvoice");
      }
    )
  }

  addNewIssueRaw(){

    let newIncomingInvoice : IncomingInvoiceDTO ={
      invoiceID: this.invoiceID,
      date: this.date.toLocaleDateString('sv'),
      supplierID: "",
      invoiceItems: this.rawsToSell as RawToSell[],
      totalValueOfPdv: this.total_value_of_pdv,
      totalValueWithoutPdv: this.total_value_without_pdv,
      totalValue: this.total_value_with_pdv
    };

    this.invoicesService.addNewInternalIssueRaw(newIncomingInvoice).subscribe(
      data=>{
        this.dialogRef.close("addedNewInternalIssueRaw");
      }
    )

  }
}
