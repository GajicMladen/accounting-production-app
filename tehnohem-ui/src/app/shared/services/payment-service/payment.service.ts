import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Payment } from '../../model/payment/payment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {


  url: string = `${environment.API_URL}/Payment`;

  constructor(private http: HttpClient) { 

  }

  addNewPayment(newPayment:Payment):Observable<any>{
    return this.http.post(this.url+"/addNewPayment",newPayment);
  }
  
  deletePayment(paymentId : string):Observable<any>{
    return this.http.delete(this.url+"/delete/"+paymentId);
  }


  getAllPaymentsOfIncomingInvoices():Observable<Payment[]>{
    return this.http.get<Payment[]>(this.url+"/getAllPaymentsIncomingInvoices");
  }
  
  getAllPaymentsOfIncomingOtherInvoices():Observable<Payment[]>{
    return this.http.get<Payment[]>(this.url+"/getAllPaymentsIncomingOtherInvoices");
  }
}
