import { Component, OnInit, Input } from "@angular/core";
import { AssistantResultItemModel } from "src/app/modules/shared/models/AssistantResultItemModel";

@Component({
  selector: "app-assistant-result-card",
  templateUrl: "./assistant-result-card.component.html",
  styleUrls: ["./assistant-result-card.component.scss"]
})
export class AssistantResultCardComponent implements OnInit {
  @Input() result: AssistantResultItemModel;

  constructor() {}

  ngOnInit(): void {}

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
}
