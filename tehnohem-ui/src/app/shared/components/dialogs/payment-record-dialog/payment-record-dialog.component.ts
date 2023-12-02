import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Company } from 'src/app/shared/model/company';
import { InternalDocumentType } from 'src/app/shared/model/internalDocumentsData';
import { DetailInvoiceInfo } from 'src/app/shared/model/invoices/detailInvoiceInfo';
import { PaymentDialogData } from 'src/app/shared/model/payment/paymentDialogData';
import { PaymentItem } from 'src/app/shared/model/payment/paymentItem';
import { PaymentType } from 'src/app/shared/model/payment/paymentType';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';
import { InvoicesService } from 'src/app/shared/services/invoices-service/invoices.service';

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

  displayedColumns: string[] = ['invoiceID','date','value_total','options' ];
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
   ){ }

  ngOnInit(): void {
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
  }

  selectedInvoice(invoice:DetailInvoiceInfo){

    this.singlePiceForm.get('name')?.setValue(invoice.invoiceID);
    this.singlePiceForm.get('value')?.setValue(invoice.valueTotal);
  }

  addNewPaymentItem(){
    let newItem: PaymentItem = {
      name: this.singlePiceForm.get('name')?.value,
      value: this.singlePiceForm.get('value')?.value
    }
    this.paymentItems = [...this.paymentItems,newItem];
  }

  deletePaymentItem(paymentItem : PaymentItem){
    this.paymentItems = this.paymentItems.filter(x => x != paymentItem);
  }

  updateTotalValues(){
    this.total_value_with_pdv = 0 ;
    this.paymentItems.forEach(x => {
      this.total_value_with_pdv += x.value;
    });
    
  }
}
