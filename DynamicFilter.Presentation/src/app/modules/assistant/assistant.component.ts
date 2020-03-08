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
import { PresentAttributesReportModel } from '../shared/models/PresentAttributesReportModel';
import { AttributeGroup } from '../shared/models/AttributeGroup';

@Component({
  selector: 'app-assistant',
  templateUrl: './assistant.component.html',
  styleUrls: ['./assistant.component.scss']
})
export class AssistantComponent implements OnInit {


  public isInit = false;

  constructor(private apiService: ApiService, private formBuilder: FormBuilder) { 
    this.apiService.getAllPresentAttributes().subscribe(response => {
      this.presentAttributes = response;
      this.setFormArrayFromAttributes();
      this.isInit = true;
    });
  }

  searchExecuted = false;
  assistantFormGroup: FormGroup;
  searchResult: AssistantResultModel;

  presentAttributes: PresentAttributesReportModel;

  public assistantRequestModel: AssistantRequestModel;

  ngOnInit(): void {
    this.assistantFormGroup = this.formBuilder.group({
    });
    console.log(this.assistantRequestModel);

  }

  public calculateOptimalItems(): void {
    let request = <AssistantRequestModel> {
      preferenceAttributes: [],
      preferenceAttributeGroups: []
    };

    let mergedAttributes: SearchAttributeModel[] = this.mergedAttributes();

    for (let [key, control] of Object.entries(this.assistantFormGroup.controls)) {
      if (!control || control.value == null) continue;
      if (key == "name") {
        continue;
      }

      let groupName;
      let name = key;
      if(key.includes('-$-')) {
        let splits = key.split('-$-');
        groupName = splits[0];
        name = splits[1];
      }

      let obj = mergedAttributes.find(a => a.name == name && a.values.includes(control.value));
      if(!obj && ['true', 'false'].includes(control.value)) {
         obj = mergedAttributes.find(a => a.name == name);
      }
      if (!obj) {
        return;
      }
      let type = obj.type;
      let weight = obj.weight;
      if (type == AttributeType.bool && control.value == false) {
        continue;
      }
      if (type == AttributeType.bool && control.value == false) {
        continue;
      }

      if(groupName) {
        if(!request.preferenceAttributeGroups.map(x=> x.name).includes(groupName)) {
          request.preferenceAttributeGroups.push(<AttributeGroup>{
            name: groupName,
            attributes: []
          });
        }
        request.preferenceAttributeGroups.find(x=> x.name == groupName).attributes.push(<Attribute>{
          name: name,
          value: control.value,
          type: type,
          weight: weight
        });
      }
      else{
        request.preferenceAttributes.push(<Attribute>{
          name: name,
          value: control.value,
          type: type,
          weight: weight
        });
      }
    }
    this.assistantRequestModel = request;
    this.apiService.calculateOptimalItems(this.assistantRequestModel).subscribe(response => {
      this.searchExecuted = true;
      this.searchResult = response;
    });
  }

  setFormArrayFromAttributes() {
    this.presentAttributes.attributes.forEach(attribute => {
      this.assistantFormGroup.addControl(
        attribute.name,
        this.formBuilder.control({
          [attribute.name]: ""
        })
      );
    });

    this.presentAttributes.attributeGroups.forEach(attributeGroup => {
      attributeGroup.attributes.forEach(attribute => {
        let controlName = attributeGroup.name + '-$-' + attribute.name;
        this.assistantFormGroup.addControl(
          controlName,
          this.formBuilder.control({
            [controlName]: ""
          })
        );
      });
    });
    this.assistantFormGroup.reset();
  }

  mergedAttributes(): SearchAttributeModel[] {
    let result: SearchAttributeModel[] = [];
    if(this.presentAttributes.attributes) {
      result.push(...this.presentAttributes.attributes);
    }
    if(this.presentAttributes.attributeGroups){
      this.presentAttributes.attributeGroups.forEach(attributeGroup => {
        result.push(...attributeGroup.attributes);
      })
    }
    return result;
  }
}
