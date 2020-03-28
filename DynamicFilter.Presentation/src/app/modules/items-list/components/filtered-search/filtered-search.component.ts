import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  OnDestroy,
  AfterViewInit
} from "@angular/core";
import { COMMA, ENTER } from "@angular/cdk/keycodes";
import { Item } from "src/app/modules/shared/models/Item";
import { ApiService } from "src/app/services/api.service";
import { Subject } from "rxjs";
import { SearchAttributeModel } from "src/app/modules/shared/models/SearchAttributeModel";
import { FormBuilder, FormGroup, FormControl } from "@angular/forms";
import { AttributeType } from "src/app/modules/shared/models/AttributeType.enum";
import { Attribute } from "src/app/modules/shared/models/Attribute";
import { FilterChip } from "src/app/modules/shared/models/FilterChip";
import { PresentAttributesReportModel } from "src/app/modules/shared/models/PresentAttributesReportModel";
import { AttributeGroup } from 'src/app/modules/shared/models/AttributeGroup';

@Component({
  selector: "app-filtered-search",
  templateUrl: "./filtered-search.component.html",
  styleUrls: ["./filtered-search.component.scss"]
})
export class FilteredSearchComponent
  implements OnInit, OnDestroy, AfterViewInit {
  @Output() searchExecuted = new EventEmitter<Item[]>();

  public isInit = false;
  public searchResult: Item[] = [];
  public presentAttributes: PresentAttributesReportModel;
  public filterItem: Item = {
    id: "",
    name: "",
    attributes: [],
    attributeGroups: [],
    iconUrl: "",
    description: "",
    websiteUrl: ""
  };
  public visible = true;
  public selectable = true;
  public removable = true;
  public addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  public chips: FilterChip[] = [];

  public unsubscribe = new Subject();

  public filterFormGroup: FormGroup;

  constructor(
    private apiService: ApiService,
    private formBuilder: FormBuilder
  ) {
    this.apiService.getAllPresentAttributes().subscribe(response => {
      this.presentAttributes = response;
      this.setFormArrayFromAttributes();
      this.isInit = true;
    });
  }

  ngOnInit(): void {
    this.filterFormGroup = this.formBuilder.group({
      name: new FormControl("")
    });

    this.filterFormGroup.valueChanges.subscribe(form => {
      this.updateFilterItem(form);
      this.search(this.filterItem);
    });

    this.apiService.getAllItems().subscribe(response => {
      this.searchResult = response;
      this.searchExecuted.emit(response);
    });
  }

  ngAfterViewInit(): void {}

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

  public updateFilterItem(form: any): void {
    if(!this.isInit) {
      return;
    }
    let newChips: FilterChip[] = [];

    let formItem = <Item>{
      name: this.filterFormGroup.get("name").value,
      attributes: [],
      attributeGroups: []
    };
    if (formItem.name && formItem.name != "") {
      newChips.push(<FilterChip>{
        controlName: "name",
        value: `Name: ${formItem.name}`
      });
    }
    let mergedAttributes: SearchAttributeModel[] = this.mergedAttributes();

    for (let [key, control] of Object.entries(this.filterFormGroup.controls)) {
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

      let obj: SearchAttributeModel = mergedAttributes.find(
        a => a.name == name && a.values.includes(control.value)
      );
      if (!obj && ["true", "false"].includes(control.value)) {
        obj = mergedAttributes.find(a => a.name == name);
      }
      if (!obj) {
        return;
      }
      let type = obj["type"];
      if (type == AttributeType.bool && control.value == false) {
        continue;
      }

      if(groupName) {
        if(!formItem.attributeGroups.map(x=> x.name).includes(groupName)) {
          formItem.attributeGroups.push(<AttributeGroup>{
            name: groupName,
            attributes: []
          });
        }
        formItem.attributeGroups.find(x=> x.name == groupName).attributes.push(<Attribute>{
          name: name,
          value: control.value,
          type: type,
          weight: undefined
        });
        if (type == AttributeType.bool) {
          newChips.push(<FilterChip>{
            controlName: key,
            value: `[${groupName}] ${name}: ${control.value == "true" ? "Yes" : "No"}`
          });
        } else {
          newChips.push(<FilterChip>{
            controlName: key,
            value: `[${groupName}] ${name}: ${control.value}`
          });
        }
      }
      else{
        formItem.attributes.push(<Attribute>{
          name: name,
          value: control.value,
          type: type,
          weight: undefined
        });
        if (type == AttributeType.bool) {
          newChips.push(<FilterChip>{
            controlName: key,
            value: `${name}: ${control.value == "true" ? "Yes" : "No"}`
          });
        } else {
          newChips.push(<FilterChip>{
            controlName: key,
            value: `${name}: ${control.value}`
          });
        }
      }


    }
    this.filterItem = formItem;
    this.chips = newChips;
  }

  setFormArrayFromAttributes() {
    this.presentAttributes.attributes.forEach(attribute => {
      this.filterFormGroup.addControl(
        attribute.name,
        this.formBuilder.control({
          [attribute.name]: ""
        })
      );
    });

    this.presentAttributes.attributeGroups.forEach(attributeGroup => {
      attributeGroup.attributes.forEach(attribute => {
        let controlName = attributeGroup.name + '-$-' + attribute.name;
        this.filterFormGroup.addControl(
          controlName,
          this.formBuilder.control({
            [attribute.name]: ""
          })
        );
      });
    });
    this.filterFormGroup.reset();
  }

  public search(filterItem: Item): void {
    if(!this.isInit) {
      return;
    }
    this.apiService.getItemsWithFilter(filterItem).subscribe(response => {
      this.searchResult = response;
      this.searchExecuted.emit(response);
    });
  }

  public removeChip(filterChip: FilterChip) {
    this.filterFormGroup.get(filterChip.controlName).reset();
  }

  public ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }


}
