import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  OnDestroy,
  AfterViewInit
} from "@angular/core";
import { Item } from "src/app/modules/shared/models/Item";
import { ApiService } from "src/app/services/api.service";
import { Subject } from "rxjs";
import { SearchAttributeModel } from "src/app/modules/shared/models/SearchAttributeModel";
import { FormBuilder, FormGroup, FormControl } from "@angular/forms";
import { AttributeType } from "src/app/modules/shared/models/AttributeType.enum";
import { Attribute } from "src/app/modules/shared/models/Attribute";

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
    attributes: []
  };

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
    let formItem = <Item>{
      name: this.filterFormGroup.get("name").value,
      attributes: []
    };

    for (let [key, control] of Object.entries(this.filterFormGroup.controls)) {
      console.log(key, control.value);
      if (!control || control.value == null) continue;
      if (key == "name") {
        continue;
      }
      let type: AttributeType;
      switch (typeof control.value) {
        case "number":
          type = AttributeType.int;
          break;
        case "string":
          type = AttributeType.string;
          break;
        case "boolean":
          type = AttributeType.bool;
          break;
      }
      if (type == AttributeType.bool && control.value == false) {
        continue;
      }
      formItem.attributes.push(<Attribute>{
        name: key,
        value: control.value,
        type: type,
        weight: undefined
      });
    }
    this.filterItem = formItem;
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

  public ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
