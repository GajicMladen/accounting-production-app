import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ExcelService {

  url: string = `${environment.API_URL}/Excel`;

  constructor(private http: HttpClient) { }

  getInvoiceExcelFile(invoiceSystemId: string):Observable<any>{
    return this.http.get(this.url+"/getInvoiceFile/"+invoiceSystemId,{ responseType:'blob'});
  }

}
