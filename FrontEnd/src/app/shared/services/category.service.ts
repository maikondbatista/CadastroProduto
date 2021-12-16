import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { EnpointConstants } from '../constants/endpoint.constants';
import { Category } from '../models/category.model';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  public categorySubject: Subject<Category> = new Subject<Category>();
  urlCategoryApi!: string;

  constructor(private http: HttpClient, configService: ConfigService) {
    this.urlCategoryApi = configService.configJson.urlCategoriaApi;
  }

  setCategory(category: Category) {
    this.categorySubject.next(category);
  }

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.urlCategoryApi + EnpointConstants.getAllCategory);
  }

  Save(value: Category): Observable<Category> {
    return this.http.post<Category>(this.urlCategoryApi + EnpointConstants.postCategory, value);
  }
  Update(value: Category): Observable<Category> {
    return this.http.put<Category>(this.urlCategoryApi + EnpointConstants.putCategory, value);
  }
  Delete(value: Category): Observable<string>{
    return this.http.delete<string>(this.urlCategoryApi + EnpointConstants.deleteCategory+value.id);
  }
}
