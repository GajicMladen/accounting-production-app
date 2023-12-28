import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IncomingInvoiceDTO } from '../../model/invoices/incomingInvoiceDTO';
import { DetailInvoiceInfo } from '../../model/invoices/detailInvoiceInfo';
import { OutgoingInvoiceDTO } from '../../model/invoices/outgoingInvoiceDTO';

@Injectable({
  providedIn: 'root'
})
export class InvoicesService {

  url: string = `${environment.API_URL}/Invoices`;

  constructor(private http: HttpClient) { }


  addNewIncomingInvoice(incomingInvoiceDTO:IncomingInvoiceDTO):Observable<any>{
    return this.http.post<any>(this.url+"/addNewIncomingInvoice",incomingInvoiceDTO);
  }

  addNewIncomingOtherInvoice(incomingInvoiceDTO:IncomingInvoiceDTO):Observable<any>{
    return this.http.post<any>(this.url+"/addNewIncomingOtherInvoice",incomingInvoiceDTO);
  }

  addNewOutgoingInvoice(outgoingInvoiceDTO:OutgoingInvoiceDTO):Observable<any>{
    return this.http.post<any>(this.url+"/addNewOutgoingInvoice",outgoingInvoiceDTO);
  }
  addNewInternalIssueRaw(incomingInvoiceDTO:IncomingInvoiceDTO):Observable<any>{
    return this.http.post<any>(this.url+"/addNewInternalIssueRaw",incomingInvoiceDTO);
  }

  addNewInternalIssueProduct(incomingInvoiceDTO:IncomingInvoiceDTO):Observable<any>{
    return this.http.post<any>(this.url+"/addNewInternalIssueProduct",incomingInvoiceDTO);
  }

  getAllIncomingInvoices():Observable<DetailInvoiceInfo[]>{
    return this.http.get<DetailInvoiceInfo[]>(this.url+"/allIncomingInvoices");
  }
  
  getAllIncomingOtherInvoices():Observable<DetailInvoiceInfo[]>{
    return this.http.get<DetailInvoiceInfo[]>(this.url+"/allIncomingOtherInvoices");
  }
  
  getAllInternalIssueRaw():Observable<DetailInvoiceInfo[]>{
    return this.http.get<DetailInvoiceInfo[]>(this.url+"/allInternalIssueRaw");
  }
  
  getAllInternalIssueProduct():Observable<DetailInvoiceInfo[]>{
    return this.http.get<DetailInvoiceInfo[]>(this.url+"/allInternalIssueProduct");
  }

  getAllOutgoingInvoices():Observable<DetailInvoiceInfo[]>{
    return this.http.get<DetailInvoiceInfo[]>(this.url+"/allOutgoingInvoices");
  }
  
  getAllOutgoingCashInvoices():Observable<DetailInvoiceInfo[]>{
    return this.http.get<DetailInvoiceInfo[]>(this.url+"/allOutgoingCashInvoices");
  }

  deleteInvoice(invoiceId: string):Observable<any>{
    return this.http.delete<any>(this.url+"/deleteInvoice/"+invoiceId);
  }
}

