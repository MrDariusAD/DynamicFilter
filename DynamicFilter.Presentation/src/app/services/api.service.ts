import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Item } from '../modules/shared/models/Item';
import { SearchAttributeModel } from '../modules/shared/models/SearchAttributeModel';
import { AssistantRequestModel } from '../modules/shared/models/AssistantRequestModel';
import { AssistantResultModel } from '../modules/shared/models/AssistantResultModel';
import { PresentAttributesReportModel } from '../modules/shared/models/PresentAttributesReportModel';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl: string = 'http://webapi.dynamicfilter.maikunity.de:32787/api' //http://93.194.50.165:5000/api | https://localhost:5001/api | http://webapi.dynamicfilter.maikunity.de:32787/api

  constructor(private httpClient: HttpClient) { }
  
  public getAllItems() {
    return this.httpClient.get<Item[]>(this.baseUrl + '/DynamicFilter/LoadAllItems');
  }
  public getItemsWithFilter(filterItem: Item) {
    return this.httpClient.post<Item[]>(this.baseUrl + `/DynamicFilter/LoadWithFilter`,filterItem);
  }
  public getAllPresentAttributes() {
    return this.httpClient.get<PresentAttributesReportModel>(this.baseUrl + '/DynamicFilter/GetAllPresentAttributes');
  }
  public calculateOptimalItems(request: AssistantRequestModel) {
    return this.httpClient.post<AssistantResultModel>(this.baseUrl + `/Assistant/CalculateOptimalItems`,request);
  }
  public checkLicense() {
    return this.httpClient.get<boolean>(this.baseUrl + `/Licensing/CheckActivation`)
  }
  public activateLicense(productKey: string) {
    return this.httpClient.get<boolean>(this.baseUrl + `/Licensing/ActivateProduct?productKey=${productKey}`)
  }
}
