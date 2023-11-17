import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IncomingInvoiceDTO } from '../../model/invoices/incomingInvoiceDTO';
import { DetailInvoiceInfo } from '../../model/invoices/detailInvoiceInfo';

@Injectable({
  providedIn: 'root'
})
export class InvoicesService {

  url: string = `${environment.API_URL}/Invoices`;

  constructor(private http: HttpClient) { }


  addNewIncomingInvoice(incomingInvoiceDTO:IncomingInvoiceDTO):Observable<any>{
    return this.http.post<any>(this.url+"/addNewIncomingInvoice",incomingInvoiceDTO);
  }

  addNewInternalIssueRaw(incomingInvoiceDTO:IncomingInvoiceDTO):Observable<any>{
    return this.http.post<any>(this.url+"/addNewInternalIssueRaw",incomingInvoiceDTO);
  }

  getAllIncomingInvoices():Observable<DetailInvoiceInfo[]>{
    return this.http.get<DetailInvoiceInfo[]>(this.url+"/allIncomingInvoices");
  }
  
  getAllInternalIssueRaw():Observable<DetailInvoiceInfo[]>{
    return this.http.get<DetailInvoiceInfo[]>(this.url+"/allInternalIssueRaw");
  }
}

