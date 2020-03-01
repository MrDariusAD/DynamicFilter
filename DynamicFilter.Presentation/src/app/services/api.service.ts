import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Item } from '../modules/shared/models/Item';
import { SearchAttributeModel } from '../modules/shared/models/SearchAttributeModel';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl: string = 'https://localhost:44352/api/DynamicFilter'

  constructor(private httpClient: HttpClient) { }
  
  public getAllItems() {
    return this.httpClient.get<Item[]>(this.baseUrl + '/LoadAllItems');
  }
  public getItemsWithFilter(filterItem: Item) {
    return this.httpClient.post<Item[]>(this.baseUrl + `/LoadWithFilter`,filterItem);
  }
  public getAllPresentAttributes() {
    return this.httpClient.get<SearchAttributeModel[]>(this.baseUrl + '/GetAllPresentAttributes');
  }
}
