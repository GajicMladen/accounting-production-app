import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Raw } from '../../model/raw';

@Injectable({
  providedIn: 'root'
})
export class RawService {

  url: string = `${environment.API_URL}/Raw`;

  constructor(private http: HttpClient) { 

  }

  getAllRaws():Observable<Raw[]>{
    return this.http.get<Raw[]>(this.url+"/all")
  }

  addNewRaw(newRaw : Raw ):Observable<any>{
    return this.http.post(this.url+"/add",newRaw);
  }

  deleteRaw(rawId : number):Observable<any>{
    return this.http.delete(this.url+"/delete/"+ rawId);
  }

  editRaw(raw: Raw):Observable<any>{
    return this.http.put(this.url+"/update",raw);
  }

}
