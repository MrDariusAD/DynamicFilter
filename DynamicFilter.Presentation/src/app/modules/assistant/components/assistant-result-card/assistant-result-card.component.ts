import { Component, OnInit, Input } from "@angular/core";
import { AssistantResultItemModel } from "src/app/modules/shared/models/AssistantResultItemModel";
import { AssistantRequestModel } from 'src/app/modules/shared/models/AssistantRequestModel';

@Component({
  selector: "app-assistant-result-card",
  templateUrl: "./assistant-result-card.component.html",
  styleUrls: ["./assistant-result-card.component.scss"]
})
export class AssistantResultCardComponent implements OnInit {
  @Input() result: AssistantResultItemModel;
  @Input() request: AssistantRequestModel;

  constructor() {}

  ngOnInit(): void {
    console.log(this.request);
  }


  public percentColors = [
    { pct: 0, color: { r: 0xff, g: 0x00, b: 0 } },
    { pct: 50, color: { r: 0xff, g: 0xff, b: 0 } },
    { pct: 100, color: { r: 0x00, g: 0xff, b: 0 } }
  ];

  public getColorForPercentage(maxval, minval, val, moreisgood) {
    var intnsty = (val - minval) / (maxval - minval);
    var r, g;
    if (moreisgood) {
      if (intnsty > 0.5) {
        g = 255;
        r = Math.round(2 * (1 - intnsty) * 255);
      } else {
        r = 255;
        g = Math.round(2 * intnsty * 255);
      }
    } else {
      //lessisgood
      if (intnsty > 0.5) {
        g = 255;
        r = Math.round(2 * (1 - intnsty) * 255);
      } else {
        r = 255;
        g = Math.round(2 * intnsty * 255);
      }
    }
    return "rgb(" + r.toString() + ", " + g.toString() + ", 0)";
  }

  public isPreferencedAttribute(attributeName: string, groupName: string = null) {
    if(groupName) {
      return this.request.preferenceAttributeGroups.find(x=> x.name==groupName)?.attributes.map(x=> x.name).includes(attributeName)
    }
    return this.request.preferenceAttributes.map(x=> x.name).includes(attributeName);
  }

  public hasRequestedValue(attributeName: string, attributeValue: string, groupName: string = null) {
    let attributeInRequest;
    if(groupName) {
      attributeInRequest = this.request.preferenceAttributeGroups.find(x=> x.name==groupName)?.attributes.find(x=> x.name == attributeName);
    }
    else {
      attributeInRequest = this.request.preferenceAttributes.find(x=> x.name == attributeName);
    }
    if(!attributeInRequest) return false;
    return attributeInRequest.value == attributeValue;
  }
}
