import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../../model/company';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  url: string = `${environment.API_URL}/Company`;

  constructor(private http: HttpClient) { }


  getAllCustomerCompanies():Observable<Company[]>{
    return this.http.get<Company[]>(this.url+"/customers")
  }

  getAllSupplierCompanies():Observable<Company[]>{
    return this.http.get<Company[]>(this.url+"/suppliers")
  }

  getAllThirdPartyCompanies():Observable<Company[]>{
    return this.http.get<Company[]>(this.url+"/thirdPartyCompanies")
  }

  addNewCompany(newCompany : Company):Observable<any>{
    return this.http.post<any>(this.url+ "/addNewCompany" , newCompany);
  }
  
  deleteCompany(companyId: string): Observable<any>{
    return this.http.delete<any>(this.url+"/deleteCompany/"+companyId);
  }

  getAllDeliveryPlaces( companyId: string):Observable<any>{
    return this.http.get<any>(this.url+"/deliveryPlaces/"+companyId);
  }

  updateCompany(company: Company):Observable<any>{
    return this.http.post<any>(this.url+"/update", company);
  }

  getCompanyInfo(companyId : string): Observable<Company>{
    return this.http.get<Company>(this.url+"/info/"+companyId);
  }

}

