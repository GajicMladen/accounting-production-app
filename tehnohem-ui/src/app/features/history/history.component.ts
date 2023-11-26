import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DetailInvoiceInfo } from 'src/app/shared/model/invoices/detailInvoiceInfo';
import { InvoicesService } from 'src/app/shared/services/invoices-service/invoices.service';
import { izlazneFakture } from 'src/app/shared/test-data/test-data-bussines';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {


  @Input() tabToShow:number = 0;

  range = new FormGroup({
    start: new FormControl(null),
    end: new FormControl(null),
  });
  
  table1Data = izlazneFakture;
  
  invoicesIncoming: DetailInvoiceInfo[] =[];
  invoicesInternalIssueRaw: DetailInvoiceInfo[] =[];
  invoicesInternalIssueProduct: DetailInvoiceInfo[] =[];
  invoicesOutgoing: DetailInvoiceInfo[] =[];

  displayedColumnsIncomingInvoice: string[] = [ 'supplierName','invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total' ];
  displayedColumnsIssueRaw: string[]= ['invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total' ];
  displayedColumnsIssueProduct: string[]= ['invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total' ];
  displayedColumnsOutgoingInvoice: string[] = [ 'customerName','invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total' ];

  statistics: boolean = true;

  total_value_out_pdv:number = 0;
  total_value_pdv : number= 0;
  total_value : number = 0;

  constructor(
    private invoicesService:InvoicesService
  ) { }

  ngOnInit(): void {
    this.invoicesService.getAllIncomingInvoices().subscribe(data =>{
      this.invoicesIncoming = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
    });

    this.invoicesService.getAllInternalIssueRaw().subscribe(data =>{
      this.invoicesInternalIssueRaw = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
    });

    this.invoicesService.getAllInternalIssueProduct().subscribe(data =>{
      this.invoicesInternalIssueProduct = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
    });
    
    this.invoicesService.getAllOutgoingInvoices().subscribe(data =>{
      this.invoicesOutgoing = data.sort(function(a,b): any{
        return Date.parse(b.date.toString()) - Date.parse(a.date.toString());
      });
    });
  }

  onChange(){
    
  }
}
