import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Company } from 'src/app/shared/model/company';
import { CompanyType } from 'src/app/shared/model/enums/companyType';
import { DetailInvoiceInfo } from 'src/app/shared/model/invoices/detailInvoiceInfo';
import { InvoicesService } from 'src/app/shared/services/invoices-service/invoices.service';
import { TabService } from 'src/app/shared/services/tabService/tab.service';
import { izlazneFakture } from 'src/app/shared/test-data/test-data-bussines';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit  {


  @Input() tabToShow:number = 0;

  suppliers : Company[] = [];
  customers: Company[] = [];

  selectorName: string = "Dobavljač";
  selectData : Company[] = [];
  
  range = new FormGroup({
    start: new FormControl(null),
    end: new FormControl(null),
  });
  
  table1Data = izlazneFakture;
  
  allInvoicesIncoming: DetailInvoiceInfo[] =[];
  invoicesIncoming: DetailInvoiceInfo[] =[];
  
  allInvoicesInternalIssueRaw: DetailInvoiceInfo[] =[];
  invoicesInternalIssueRaw: DetailInvoiceInfo[] =[];
  
  allInvoicesInternalIssueProduct: DetailInvoiceInfo[] =[];
  invoicesInternalIssueProduct: DetailInvoiceInfo[] =[];
  
  allInvoicesOutgoing: DetailInvoiceInfo[] =[];
  allInvoicesCashOutgoing : DetailInvoiceInfo[] = [];
  invoicesOutgoing: DetailInvoiceInfo[] =[];

  displayedColumnsIncomingInvoice: string[] = [ 'supplierName','invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total','options' ];
  displayedColumnsIssueRaw: string[]= ['invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total','options' ];
  displayedColumnsIssueProduct: string[]= ['invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total','options' ];
  displayedColumnsOutgoingInvoice: string[] = [ 'customerName','invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total','options' ];

  statistics: boolean = true;
  cashFlow: boolean = false;

  total_value_out_pdv:number = 0;
  total_value_pdv : number= 0;
  total_value : number = 0;

  constructor(
    private invoicesService:InvoicesService,
    private tabService: TabService,
  ) { }

  ngOnInit(): void {
    this.tabService.getTab$().subscribe(data => {
      this.tabToShow = data;
    });
    this.getAllData();

  }

  updateTab(tabToShow : number){
    if(tabToShow === 5.1)
      this.selectData = this.suppliers;
    else if(tabToShow === 5.4)
      this.selectData = this.customers;
    
  }

  getAllData(){
    this.invoicesService.getAllIncomingInvoices().subscribe(data =>{
      this.allInvoicesIncoming = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
      this.invoicesIncoming = this.allInvoicesIncoming;
      this.allInvoicesIncoming.forEach(x => {
        let company : Company ={
          id: x.supplierID,
          name: x.supplierName,
          jib: '',ib: '',address: '',phoneNumber: undefined,email: '',companyType: CompanyType.SUPPLIER,contactPerson: '',headCompanyId: undefined}
        this.suppliers.findIndex((item) => item.id === company.id) === -1 ? this.suppliers.push(company) : null;
      });
      this.updateTab(this.tabToShow);
    });

    this.invoicesService.getAllInternalIssueRaw().subscribe(data =>{
      this.allInvoicesInternalIssueRaw = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
      this.invoicesInternalIssueRaw = this.allInvoicesInternalIssueRaw;
    });

    this.invoicesService.getAllInternalIssueProduct().subscribe(data =>{
      this.allInvoicesInternalIssueProduct = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
      this.invoicesInternalIssueProduct = this.allInvoicesInternalIssueProduct;
    });
    
    this.invoicesService.getAllOutgoingInvoices().subscribe(data =>{
      this.allInvoicesOutgoing = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
      this.invoicesOutgoing = this.allInvoicesOutgoing;
      this.allInvoicesOutgoing.forEach(x => {
        let company : Company ={
          id: x.customerID,
          name: x.customerName,
          //unnessesary fields in this case
          jib: '',ib: '',address: '',phoneNumber: undefined,email: '',companyType: CompanyType.SUPPLIER,contactPerson: '',headCompanyId: undefined
        }
        this.customers.findIndex((item) => item.id === company.id) === -1 ?  this.customers.push(company) : null;
      });
      this.updateTab(this.tabToShow);
    });

    this.invoicesService.getAllOutgoingCashInvoices().subscribe(data =>{
      this.allInvoicesCashOutgoing = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
      this.allInvoicesCashOutgoing.forEach(x => {
        let company : Company ={
          id: x.customerID,
          name: x.customerName,
          //unnessesary fields in this case
          jib: '',ib: '',address: '',phoneNumber: undefined,email: '',companyType: CompanyType.SUPPLIER,contactPerson: '',headCompanyId: undefined
        }
        this.customers.findIndex((item) => item.id === company.id) === -1 ?  this.customers.push(company) : null;
      });
    })
  }

  filterTables(selectValue:string){
    if(selectValue != "~"){
      if(this.tabToShow === 5.1 ){
        this.invoicesIncoming = this.allInvoicesIncoming.filter(x => x.supplierID === selectValue);
      }
      else if( this.tabToShow === 5.4){
        this.invoicesOutgoing = this.invoicesOutgoing.filter(x => x.customerID === selectValue);
      }
    }
    else{
      if(this.tabToShow === 5.1 ){
        this.invoicesIncoming = this.allInvoicesIncoming;
      }
      if( this.tabToShow === 5.4){
        this.includeCashFlow();
      }
    }
  }

  includeCashFlow(){
    if(this.cashFlow){
      this.invoicesOutgoing = [...this.allInvoicesCashOutgoing,...this.allInvoicesOutgoing]
    }
    else{
      this.invoicesOutgoing = [...this.allInvoicesOutgoing]
    }
    this.invoicesOutgoing = this.invoicesOutgoing.sort(function(a,b): any{
      return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
    });
  }
}
