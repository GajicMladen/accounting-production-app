import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { PaymentRecordDialogComponent } from 'src/app/shared/components/dialogs/payment-record-dialog/payment-record-dialog.component';
import { Company } from 'src/app/shared/model/company';
import { Expenses } from 'src/app/shared/model/expenses';
import { DetailInvoiceInfo } from 'src/app/shared/model/invoices/detailInvoiceInfo';
import { PaymentType } from 'src/app/shared/model/payment/paymentType';
import { InvoicesService } from 'src/app/shared/services/invoices-service/invoices.service';
import { customers, dugovanja, dugovanjaOstala, getters, izlazneFakture, thirdFaces, uplate, uplateKupci, uplateOstalo } from 'src/app/shared/test-data/test-data-bussines';

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

  table1Data: DetailInvoiceInfo[] = []; 
  table2Data: DetailInvoiceInfo[] = [];
  selectData : Company[] =getters;

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
    private invoicesService : InvoicesService
  ) { }

  ngOnInit(): void {
    this.updateTab(this.shownTab);
  }

  updateTab(shownTabT:number){
    this.shownTab = shownTabT;
    if( this.shownTab === 6.11){
  
      this.selectorName  = "Dobavljč";
      this.table1Title  = "Ulazne fakture";
      this.table2Title = "Moje Uplate";
      this.table1Btn1 = "Evidentiraj novu ulaznu fakturu";
      this.table2Btn1 = "Evidentiraj novo razduzivanje ulaznih faktura";
      
      // this.table1Data = dugovanja; 
      // this.table2Data = uplate;
      // this.selectData  =getters;

      this.table2Btn1Action = this.openIncomingInvoicePayment;

      this.invoicesService.getAllIncomingInvoices().subscribe(
        data=>{
          this.table1Data = data;
          this.updateSummary();

        }
      );


    }
    else if( this.shownTab === 6.12){
      
      this.selectorName  = "Treće lice";
      this.table1Title  = "Ostali troškovi";
      this.table2Title = "Moje uplate";
      this.table1Btn1 = "Evidentiraj novi ostali trošak";
      this.table2Btn1 = "Evidentiraj novo razduzivanje ostalih troškova";

      // this.selectData = thirdFaces;
      // this.table1Data = dugovanjaOstala;
      // this.table2Data = uplateOstalo;

    }
    else if( this.shownTab === 6.21){
      
      this.selectorName  = "Odaberi kupca";
      this.table1Title  = "Izlazne fakture";
      this.table2Title = "Uplate kupaca";
      this.table1Btn1 = "Evidentiraj novu izlaznu fakturu";
      this.table2Btn1 = "Evidentiraj novo razduzivanje od strane kupca";

      this.table2Btn1Action = this.openOutgoingInvoicePayment;
      // this.selectData = customers;
      // this.table1Data = izlazneFakture;
      // this.table2Data = uplateKupci;

      
    }
    else if( this.shownTab === 6.3){
      
      this.selectorName  = "~";
      this.table1Title  = "Rashodi";
      this.table2Title = "Prihodi";
      this.table1Btn1 = "Dodaj novi rashod";
      this.table2Btn1 = "~";

      // this.selectData = customers;
      // this.table1Data = [...dugovanja,...dugovanjaOstala];
      // this.table2Data = izlazneFakture;
      
    }
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
      this.summaryTable2 += x.valueTotal;
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
    this.updateTab(this.shownTab);
    if(selectValue != "~"){
      this.table1Data = this.table1Data.filter( x => x.customerName == selectValue);
      this.table2Data = this.table2Data.filter( x => x.customerName == selectValue);
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
          this.updateTab(this.shownTab);
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
          this.updateTab(this.shownTab);
        }
      }
    )
  }
}
