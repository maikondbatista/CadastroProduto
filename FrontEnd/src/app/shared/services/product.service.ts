import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { EnpointConstants } from '../constants/endpoint.constants';
import { Product } from '../models/product.model';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  public productSubject: Subject<Product> = new Subject<Product>();
  urlProductApi!: string;
  
  constructor(private http: HttpClient, configService: ConfigService) {
    this.urlProductApi = configService.configJson.urlProdutoApi;
  }

  setProduct(category: Product) {
    this.productSubject.next(category);
  }

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(this.urlProductApi + EnpointConstants.getAllProduct);
  }

  Save(value: Product): Observable<Product> {
    return this.http.post<Product>(this.urlProductApi + EnpointConstants.postProduct, value);
  }
  Update(value: Product): Observable<Product> {
    return this.http.put<Product>(this.urlProductApi + EnpointConstants.putProduct, value);
  }
  Delete(value: Product): Observable<string>{
    return this.http.delete<string>(this.urlProductApi + EnpointConstants.deleteProduct+value.id);
  }

}
