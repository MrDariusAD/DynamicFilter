import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Item } from '../modules/shared/models/Item';
import { SearchAttributeModel } from '../modules/shared/models/SearchAttributeModel';
import { AssistantRequestModel } from '../modules/shared/models/AssistantRequestModel';
import { AssistantResultModel } from '../modules/shared/models/AssistantResultModel';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl: string = 'https://localhost:44352/api'

  constructor(private httpClient: HttpClient) { }
  
  public getAllItems() {
    return this.httpClient.get<Item[]>(this.baseUrl + '/DynamicFilter/LoadAllItems');
  }
  public getItemsWithFilter(filterItem: Item) {
    return this.httpClient.post<Item[]>(this.baseUrl + `/DynamicFilter/LoadWithFilter`,filterItem);
  }
  public getAllPresentAttributes() {
    return this.httpClient.get<SearchAttributeModel[]>(this.baseUrl + '/DynamicFilter/GetAllPresentAttributes');
  }
  public calculateOptimalItems(request: AssistantRequestModel) {
    return this.httpClient.post<AssistantResultModel>(this.baseUrl + `/Assistant/CalculateOptimalItems`,request);
  }
}
