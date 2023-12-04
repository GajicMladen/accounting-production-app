import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/shared/model/company';
import { InternalDocumentType } from 'src/app/shared/model/enums/invoiceType';
import { DetailInvoiceInfo } from 'src/app/shared/model/invoices/detailInvoiceInfo';
import { Payment } from 'src/app/shared/model/payment/payment';
import { PaymentDialogData } from 'src/app/shared/model/payment/paymentDialogData';
import { PaymentItem } from 'src/app/shared/model/payment/paymentItem';
import { PaymentType } from 'src/app/shared/model/payment/paymentType';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';
import { InvoicesService } from 'src/app/shared/services/invoices-service/invoices.service';
import { PaymentService } from 'src/app/shared/services/payment-service/payment.service';

@Component({
  selector: 'app-payment-record-dialog',
  templateUrl: './payment-record-dialog.component.html',
  styleUrls: ['./payment-record-dialog.component.css']
})
export class PaymentRecordDialogComponent implements OnInit {

  allPaymentTypes = PaymentType;
  
  paymentID : string = "";
  date : Date = new Date();

  companies : Company[] = [];
  selectedCompany? : Company ;
  showCompany : boolean = true;

  displayedColumnsInvoicesTable : string[] = ['invoiceID','date','value_total','options' ];
  
  displayedColumnsPaymentItemsTable : string[]  = [ 'name', 'value','options'];
  invoices : DetailInvoiceInfo[] = [];

  singlePiceForm: FormGroup = new FormGroup({
    name: new FormControl(),
    value: new FormControl()
  });

  paymentItems : PaymentItem[] = [] ;

  total_value_without_pdv : number = 0;
  total_value_of_pdv : number = 0;
  total_value_with_pdv: number = 0;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: PaymentDialogData,
    private companyService: CompanyService,
    private invoicesService: InvoicesService,
    private paymentService: PaymentService,
    private toastr: ToastrService,
   ){ }

  ngOnInit(): void {
    if(this.data.isReadonly){
      this.fillProvidedDataForReadonly();
    }


    if( this.data.paymentType === PaymentType.INCOMING_INVOICE_PAYMENT){
      this.companyService.getAllSupplierCompanies().subscribe(data => {
        this.companies = data;
      });
    }
    else if( this.data.paymentType === PaymentType.OUTGOING_INVOICE_PAYMENT){
      this.companyService.getAllCustomerCompanies().subscribe(data =>{
        this.companies = data;
      });
    }
  }

  fillProvidedDataForReadonly(){

    this.paymentID = this.data.payment!.paymentId;
    this.date = new Date(this.data.payment!.date);
    this.paymentItems = this.data.payment!.paymentItems;
    let companyId = this.data.payment!.payerID;
    if(this.data.paymentType == PaymentType.INCOMING_INVOICE_PAYMENT){
      companyId = this.data.payment!.receiverID;
    }
    this.companyService.getCompanyInfo(companyId).subscribe(data=>{
        this.selectedCompany = data;
      }
    )
    
    this.displayedColumnsPaymentItemsTable = [ 'name', 'value'];
    this.updateTotalValues();
  }

  changeSelectedCompany(selectedCompany : Company){
    this.selectedCompany = selectedCompany;
    if( this.data.paymentType === PaymentType.INCOMING_INVOICE_PAYMENT){
      this.invoicesService.getAllIncomingInvoices().subscribe(data => {
        this.invoices = data.filter(x => x.supplierID === selectedCompany.id);
      });
    }
    else if( this.data.paymentType === PaymentType.OUTGOING_INVOICE_PAYMENT){
      this.invoicesService.getAllIncomingInvoices().subscribe(data =>{
        this.invoices = data.filter(x => x.customerID === selectedCompany.id);
      });
    }
    this.paymentItems = [];
    this.updateTotalValues();
  }

  selectedInvoice(invoice:DetailInvoiceInfo){

    this.singlePiceForm.get('name')?.setValue(invoice.invoiceID);
    this.singlePiceForm.get('value')?.setValue(invoice.valueTotal);
  }

  addNewPaymentItem(){
    let newItem: PaymentItem = {
      id: "",
      name: this.singlePiceForm.get('name')?.value,
      value: this.singlePiceForm.get('value')?.value
    }
    this.paymentItems = [...this.paymentItems,newItem];
    this.updateTotalValues();
  }

  deletePaymentItem(paymentItem : PaymentItem){
    this.paymentItems = this.paymentItems.filter(x => x != paymentItem);
    this.updateTotalValues();
  }

  updateTotalValues(){
    this.total_value_with_pdv = 0 ;
    this.paymentItems.forEach(x => {
      this.total_value_with_pdv += x.value;
    });
    
  }

  addNewPayment(){
    let newPayment : Payment={
      paymentId: this.paymentID,
      paymentType: PaymentType.INCOMING_INVOICE_PAYMENT,
      date: this.date.toLocaleDateString('sv'),
      payerID: "",
      payerName: "",
      receiverID: this.selectedCompany!.id,
      receiverName: this.selectedCompany!.name,
      paymentItems: this.paymentItems,
      totalValue: this.total_value_with_pdv,
    }
    this.paymentService.addNewPayment(newPayment).subscribe(
      {
        next:()=>{
          this.toastr.success("Uspešno ste evidentirali plaćanje");
        },
      }
    )
  }
}
