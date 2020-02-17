import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from '../modules/shared/models/Item';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl: string = 'https://localhost:44352/api/DynamicFilter'

  constructor(private httpClient: HttpClient) { }
  
  public getAllItems() {
    return this.httpClient.get<Item[]>(this.baseUrl + '/LoadAllItems');
  }
}
