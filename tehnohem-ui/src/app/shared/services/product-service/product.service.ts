import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../../model/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url: string = `${environment.API_URL}/Product`;

  constructor(private http: HttpClient) { 

  }

  getAllProducts():Observable<Product[]>{
    return this.http.get<Product[]>(this.url+"/all")
  }

  addNewProduct(newProduct : Product ):Observable<any>{
    return this.http.post(this.url+"/add",newProduct);
  }

  deleteProduct(ProductId : number):Observable<any>{
    return this.http.delete(this.url+"/delete/"+ ProductId);
  }

  editProduct(Product: Product):Observable<any>{
    return this.http.put(this.url+"/update",Product);
  }

}
