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

@Component({
  selector: "app-filtered-search",
  templateUrl: "./filtered-search.component.html",
  styleUrls: ["./filtered-search.component.scss"]
})
export class FilteredSearchComponent
  implements OnInit, OnDestroy, AfterViewInit {
  @Output() searchExecuted = new EventEmitter<Item[]>();

  public searchResult: Item[] = [];
  public attributes: SearchAttributeModel[] = [];
  public filterItem: Item = {
    id: "",
    name: "",
    attributes: [],
    iconUrl: ""
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
      this.attributes = response;
      this.setFormArrayFromAttributes();
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

  public updateFilterItem(form: any): void {
    let newChips: FilterChip[] = [];

    let formItem = <Item>{
      name: this.filterFormGroup.get("name").value,
      attributes: []
    };
    if (formItem.name && formItem.name != "") {
      newChips.push(<FilterChip>{
        controlName: "name",
        value: `Name: ${formItem.name}`
      });
    }
    for (let [key, control] of Object.entries(this.filterFormGroup.controls)) {
      console.log(key, control.value);
      if (!control || control.value == null) continue;
      if (key == "name") {
        continue;
      }
      // let type: AttributeType;
      // switch (typeof control.value) {
      //   case "number":
      //     type = AttributeType.int;
      //     break;
      //   case "string":
      //     type = AttributeType.string;
      //     break;
      //   case "boolean":
      //     type = AttributeType.bool;
      //     break;
      // }
      let obj: SearchAttributeModel = this.attributes.find(
        a => a.name == key && a.values.includes(control.value)
      );
      if (!obj && ["true", "false"].includes(control.value)) {
        obj = this.attributes.find(a => a.name == key);
      }
      if (!obj) {
        return;
      }
      let type = obj["type"];
      // console.log(obj.type, type);
      if (type == AttributeType.bool && control.value == false) {
        continue;
      }
      formItem.attributes.push(<Attribute>{
        name: key,
        value: control.value,
        type: type,
        weight: undefined
      });
      if (type == AttributeType.bool) {
        newChips.push(<FilterChip>{
          controlName: key,
          value: `${key}: ${control.value == "true" ? "Yes" : "No"}`
        });
      } else {
        newChips.push(<FilterChip>{
          controlName: key,
          value: `${key}: ${control.value}`
        });
      }
    }
    this.filterItem = formItem;
    this.chips = newChips;
  }

  setFormArrayFromAttributes() {
    this.attributes.forEach(attribute => {
      this.filterFormGroup.addControl(
        attribute.name,
        this.formBuilder.control({
          [attribute.name]: ""
        })
      );
    });
    this.filterFormGroup.reset();
  }

  public search(filterItem: Item): void {
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
