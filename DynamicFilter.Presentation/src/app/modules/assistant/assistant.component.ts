import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { SearchAttributeModel } from '../shared/models/SearchAttributeModel';
import { Item } from '../shared/models/Item';
import { Attribute } from '../shared/models/Attribute';
import { AttributeType } from '../shared/models/AttributeType.enum';
import { FormBuilder, FormGroup } from '@angular/forms';
import { X } from '@angular/cdk/keycodes';
import { AssistantRequestModel } from '../shared/models/AssistantRequestModel';
import { AssistantResultModel } from '../shared/models/AssistantResultModel';

@Component({
  selector: 'app-assistant',
  templateUrl: './assistant.component.html',
  styleUrls: ['./assistant.component.scss']
})
export class AssistantComponent implements OnInit {

  constructor(private apiService: ApiService, private formBuilder: FormBuilder) { 
    this.apiService.getAllPresentAttributes().subscribe(response => {
      this.attributes = response;
      this.setFormArrayFromAttributes();
    });
  }

  searchExecuted = false;
  assistantFormGroup: FormGroup;
  searchResult: AssistantResultModel;

  attributes: SearchAttributeModel[] = [];

  public assistantRequestModel: AssistantRequestModel;

  ngOnInit(): void {
    this.assistantFormGroup = this.formBuilder.group({
    });
  }

  public calculateOptimalItems(): void {
    let request = <AssistantRequestModel> {
      preferenceAttributes: []
    };

    for (let [key, control] of Object.entries(this.assistantFormGroup.controls)) {
      if (!control || control.value == null) continue;
      if (key == "name") {
        continue;
      }
      let obj = this.attributes.find(a => a.name == key && a.values.includes(control.value));
      if(!obj && ['true', 'false'].includes(control.value)) {
         obj = this.attributes.find(a => a.name == key);
      }
      let type = obj.type;
      let weight = obj.weight;
      if (type == AttributeType.bool && control.value == false) {
        continue;
      }
      request.preferenceAttributes.push(<Attribute>{
        name: key,
        value: control.value,
        type: type,
        weight: weight
      });
    }
    this.assistantRequestModel = request;

    this.apiService.calculateOptimalItems(this.assistantRequestModel).subscribe(response => {
      this.searchExecuted = true;
      this.searchResult = response;
    });
  }

  public setFormArrayFromAttributes(): void {
    this.attributes.forEach(attribute => {
      this.assistantFormGroup.addControl(
        attribute.name,
        this.formBuilder.control({
          [attribute.name]: ""
        })
      );
    });
    this.assistantFormGroup.reset();
  }

}
