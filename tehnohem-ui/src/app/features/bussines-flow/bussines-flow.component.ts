import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ConfirmDialogComponent } from 'src/app/shared/components/dialogs/confirm-dialog/confirm-dialog.component';
import { InternalDocumentsDialogComponent } from 'src/app/shared/components/dialogs/internal-documents-dialog/internal-documents-dialog.component';
import { PaymentRecordDialogComponent } from 'src/app/shared/components/dialogs/payment-record-dialog/payment-record-dialog.component';
import { Company } from 'src/app/shared/model/company';
import { Expenses } from 'src/app/shared/model/expenses';

import {InternalDocumentType } from 'src/app/shared/model/enums/invoiceType';
import { DetailInvoiceInfo } from 'src/app/shared/model/invoices/detailInvoiceInfo';
import { Payment } from 'src/app/shared/model/payment/payment';
import { PaymentType } from 'src/app/shared/model/payment/paymentType';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';
import { InvoicesService } from 'src/app/shared/services/invoices-service/invoices.service';
import { PaymentService } from 'src/app/shared/services/payment-service/payment.service';
import { customers, dugovanja, dugovanjaOstala, getters, izlazneFakture, thirdFaces, uplate, uplateKupci, uplateOstalo } from 'src/app/shared/test-data/test-data-bussines';
import { TabService } from 'src/app/shared/services/tabService/tab.service';

@Component({
  selector: 'app-bussines-flow',
  templateUrl: './bussines-flow.component.html',
  styleUrls: ['./bussines-flow.component.css']
})
export class BussinesFlowComponent implements OnInit {
  
  range = new FormGroup({
    start: new FormControl(null),
    end: new FormControl(null),
  });

  @Input() shownTab:number = 6.11; 
  
  selectorName: string = "Dobavljč";
  table1Title: string = "Sve ulazne fakture";
  table2Title:string = "Moje Uplate";
  table1Btn1:string = "Evidentiraj novu ulaznu fakturu";
  table2Btn1:string = "Evidentiraj novo razduzivanje ulaznih faktura";


  table1Btn1Action = this.openIncomingInvoicePayment;
  table2Btn1Action = this.openIncomingInvoicePayment;

  supplierCompanies : Company[] = [];
  customerCompanies: Company[] = [];
  thirdPartyCompanies: Company[] = [];

  incomingInvoices: DetailInvoiceInfo[] = [];
  incomingInvoicesPayment : Payment[] = [];

  incomingThirdPartyInvoices: DetailInvoiceInfo[] = [];
  incomingThirdPartyInvoicesPayment: Payment[] = [];

  outgoingInvoices: DetailInvoiceInfo[] = [];
  outgoingInvoicesPayment: Payment[] = [];

  outgoingCashInvoices:DetailInvoiceInfo[] = [];
  outgoingCashInvoicesPayment: Payment[] = [];

  allInvoicesTable1: DetailInvoiceInfo[] = [];
  allPaymentsTable2: Payment[] = [];
  
  table1Data: DetailInvoiceInfo[] = []; 
  table2Data: Payment[] = [];

  table2DisplayColumns: string[] = [ 'paymentID', 'payerName','receiverName','date','value_total','options' ];

  selectData : Company[] = [];

  summaryTable1:number = 0;
  summaryTable2:number = 0;
  summaryTotal:number = 0;
  
  summaryTable1PDV:number = 0;
  summaryTable2PDV:number = 0;
  summaryTotalPDV:number = 0;
  
  summaryTable1Total:number = 0;
  summaryTable2Total:number = 0;
  summaryTotalTotal:number = 0;
  
  summaryTable1String:string ="0";
  summaryTable2String:string ="0";
  summaryTotalString:string ="0";
  
  summaryTable1PDVString:string ="0";
  summaryTable2PDVString:string ="0";
  summaryTotalPDVString:string ="0";
  
  summaryTable1TotalString:string ="0";
  summaryTable2TotalString:string ="0";
  summaryTotalTotalString:string ="0";
  
  constructor(
    public dialog:MatDialog,
    private invoicesService : InvoicesService,
    private paymentService: PaymentService,
    private companyService: CompanyService,
    private toastr: ToastrService,
    private tabService:TabService
  ) { }

  ngOnInit(): void {
    this.tabService.getTab$().subscribe(data => {
      this.shownTab = data;
    });
    this.getNewValuesForInvoicesAndPayments();
  }

  getNewValuesForInvoicesAndPayments(){

    this.companyService.getAllSupplierCompanies().subscribe(
      data => {
        this.supplierCompanies = data;
        this.updateTab(this.shownTab);
      }
    );
    
    this.companyService.getAllCustomerCompanies().subscribe(
      data => {
        this.customerCompanies = data;
        this.updateTab(this.shownTab);
      }
    );

    this.companyService.getAllThirdPartyCompanies().subscribe(
      data => {
        this.thirdPartyCompanies = data;
        this.updateTab(this.shownTab);
      }
    );

    this.invoicesService.getAllIncomingInvoices().subscribe(
      data=>{
        this.incomingInvoices = data;
        this.updateTab(this.shownTab);
      }
    );
    
    this.invoicesService.getAllIncomingOtherInvoices().subscribe(
      data=>{
        this.incomingThirdPartyInvoices = data;
        this.updateTab(this.shownTab);
      }
      );
      
      this.invoicesService.getAllOutgoingInvoices().subscribe(
        data=>{
          this.outgoingInvoices = data;
          this.updateTab(this.shownTab);
        }
      );

      this.paymentService.getAllPaymentsOfIncomingInvoices().subscribe(
        data=>{
          this.incomingInvoicesPayment = data;
          this.updateTab(this.shownTab);
        }
      );
      

      this.paymentService.getAllPaymentsOfOutgoingInvoices().subscribe(
        data=>{
          this.outgoingInvoicesPayment = data;
          this.updateTab(this.shownTab);
        }
      );

      this.paymentService.getAllPaymentsOfOutgoingCashInvoices().subscribe(
        data=>{
          this.outgoingCashInvoicesPayment = data;
          this.updateTab(this.shownTab);
        }
      );

      this.paymentService.getAllPaymentsOfIncomingOtherInvoices().subscribe(
        data=>{
          this.incomingThirdPartyInvoicesPayment = data;
          this.updateTab(this.shownTab);
        }
      );
    
  }

  updateTab(shownTabT:number){
    this.shownTab = shownTabT;
    if( this.shownTab === 6.11){
  
      this.selectorName  = "Dobavljč";
      this.table1Title  = "Ulazne fakture";
      this.table2Title = "Moje Uplate";
      this.table1Btn1 = "Evidentiraj novu ulaznu fakturu";
      this.table2Btn1 = "Evidentiraj novo razduzivanje ulaznih faktura";
      
      this.table2DisplayColumns = [ 'paymentID', 'receiverName','date','value_total','options' ];

      this.table2Btn1Action = this.openIncomingInvoicePayment;

      this.allInvoicesTable1 = this.incomingInvoices;
      this.allPaymentsTable2 = this.incomingInvoicesPayment;

      this.selectData = this.supplierCompanies;
    }
    else if( this.shownTab === 6.12){
      
      this.selectorName  = "Treće lice";
      this.table1Title  = "Ostali troškovi";
      this.table2Title = "Moje uplate";
      this.table1Btn1 = "Evidentiraj novi ostali trošak";
      this.table2Btn1 = "Evidentiraj novo razduzivanje ostalih troškova";

      this.table1Btn1Action = this.openNewIncomingThirdPartyInvoice;
      this.table2Btn1Action = this.openThirdPartyPayment;

      this.allInvoicesTable1 = this.incomingThirdPartyInvoices;
      this.allPaymentsTable2 = this.incomingThirdPartyInvoicesPayment;

      this.selectData = this.thirdPartyCompanies;

    }
    else if( this.shownTab === 6.21){
      
      this.selectorName  = "Odaberi kupca";
      this.table1Title  = "Izlazne fakture";
      this.table2Title = "Uplate kupaca";
      this.table1Btn1 = "Evidentiraj novu izlaznu fakturu";
      this.table2Btn1 = "Evidentiraj novo razduživanje od strane kupca";

      this.table2Btn1Action = this.openOutgoingInvoicePayment;
      
      this.allInvoicesTable1 = this.outgoingInvoices;
      this.allPaymentsTable2 = this.outgoingInvoicesPayment;

      this.selectData = this.customerCompanies;

      
    }
    else if( this.shownTab === 6.22){
      
      this.selectorName  = "Odaberi kupca";
      this.table1Title  = "Izlazne keš fakture";
      this.table2Title = "Uplate kupaca";
      this.table1Btn1 = "Evidentiraj novu izlaznu keš fakturu";
      this.table2Btn1 = "Evidentiraj novo plaćanje od strane kupca";

      this.table2Btn1Action = this.openOutgoingInvoicePayment;
      
      this.allInvoicesTable1 = this.outgoingCashInvoices;
      this.allPaymentsTable2 = this.outgoingCashInvoicesPayment;

      this.selectData = this.customerCompanies;

      
    }
    else if( this.shownTab === 6.3){
      
      this.selectorName  = "~";
      this.table1Title  = "Rashodi";
      this.table2Title = "Prihodi";
      this.table1Btn1 = "Dodaj novi rashod";
      this.table2Btn1 = "~";

      this.allInvoicesTable1 = [...this.incomingThirdPartyInvoices,...this.incomingInvoices];
      this.allPaymentsTable2 = [...this.outgoingCashInvoicesPayment, ...this.outgoingInvoicesPayment];

      this.selectData = this.customerCompanies;
      
    }
    
    this.table1Data= this.allInvoicesTable1;
    this.table2Data = this.allPaymentsTable2;
    this.updateSummary();
  }

  updateSummary(){
    this.summaryTable1 = 0;
    this.summaryTable2 = 0;
    this.summaryTotal = 0;

    this.table1Data.forEach(x => {
      this.summaryTable1 += x.valueTotal;
    });
    
    this.table2Data.forEach(x => {
      this.summaryTable2 += x.totalValue;
    });

    this.summaryTable1PDV = this.summaryTable1 * 0.17;
    this.summaryTable2PDV = this.summaryTable2 * 0.17;
    
    this.summaryTable1Total = this.summaryTable1 + this.summaryTable1PDV;
    this.summaryTable2Total = this.summaryTable2 + this.summaryTable2PDV;
    

    this.summaryTotal  = this.summaryTable1 - this.summaryTable2;
    this.summaryTotalPDV  = this.summaryTable1PDV - this.summaryTable2PDV;
    this.summaryTotalTotal  = this.summaryTable1Total - this.summaryTable2Total;
    
    this.summaryTable1String = this.summaryTable1.toFixed(2);
    this.summaryTable2String = this.summaryTable2.toFixed(2);
    this.summaryTotalString = this.summaryTotal.toFixed(2);
    this.summaryTable1PDVString = this.summaryTable1PDV.toFixed(2);
    this.summaryTable2PDVString = this.summaryTable2PDV.toFixed(2);
    this.summaryTotalPDVString = this.summaryTotalPDV.toFixed(2);
    this.summaryTable1TotalString = this.summaryTable1Total.toFixed(2);
    this.summaryTable2TotalString = this.summaryTable2Total.toFixed(2);
    this.summaryTotalTotalString = this.summaryTotalTotal.toFixed(2);

  }

  filterTables(selectValue:string){
    if(selectValue != "~"){
      if(this.shownTab === 6.11 ||this.shownTab === 6.12 ){
        this.table1Data = this.allInvoicesTable1.filter( x => x.supplierID == selectValue);
        this.table2Data = this.allPaymentsTable2.filter( x => x.receiverID == selectValue);
      }
      else if( this.shownTab === 6.21 || this.shownTab === 6.22){
        this.table1Data = this.allInvoicesTable1.filter( x => x.customerID == selectValue);
        this.table2Data = this.allPaymentsTable2.filter( x => x.payerID == selectValue);
      }
    }
    this.updateSummary();
  }

  openIncomingInvoicePayment(){

    const dialogRefAddNewProduct = this.dialog.open(PaymentRecordDialogComponent,{
      data: { paymentType: PaymentType.INCOMING_INVOICE_PAYMENT, isReadonly:false}
    });
    dialogRefAddNewProduct.afterClosed().subscribe(
      data=>{
        if(data=="addedPayment"){
          this.getNewValuesForInvoicesAndPayments();
        }
      }
    )
  }
  
  openOutgoingInvoicePayment(){

    const dialogRefAddNewProduct = this.dialog.open(PaymentRecordDialogComponent,{
      data: { paymentType: PaymentType.OUTGOING_INVOICE_PAYMENT, isReadonly:false}
    });
    dialogRefAddNewProduct.afterClosed().subscribe(
      data=>{
        if(data=="addedPayment"){
          this.getNewValuesForInvoicesAndPayments();
        }
      }
    )
  }

  deletePayment(payment: Payment){
    
    const confirmDialog = this.dialog.open(ConfirmDialogComponent,{
      data:{
        title:"Brisanje plaćanja",
        text: " Da li želite da obrišete plaćanje: "+ payment.paymentId
      }
    });
    confirmDialog.afterClosed().subscribe(
      data=>{
        if(data){
          this.paymentService.deletePayment(payment.paymentId).subscribe({
            next: (data)=>{
                this.toastr.success("Uspešno uklonjeno");
                this.getNewValuesForInvoicesAndPayments();
            }
          });
        }
      }
    );
    
  }

  openNewIncomingThirdPartyInvoice(){

    const dialogRefAddNewProduct = this.dialog.open(InternalDocumentsDialogComponent,{
      data: { documentType : InternalDocumentType.INCOMING_OTHER_INVOICE, isReadonly:false}
    });
    dialogRefAddNewProduct.afterClosed().subscribe(
      data=>{
        if(data=="addedNewOtherInvoice"){
          this.getNewValuesForInvoicesAndPayments();
        }
      }
    )
  }

  openThirdPartyPayment(){
    
    const dialogRefAddNewProduct = this.dialog.open(PaymentRecordDialogComponent,{
      data: { paymentType: PaymentType.THIRD_PARTY_COST_PAYMENT, isReadonly:false}
    });
    dialogRefAddNewProduct.afterClosed().subscribe(
      data=>{
        if(data=="addedPayment"){
          this.getNewValuesForInvoicesAndPayments();
        }
      }
    )
  }
}
