import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AssistantComponent } from "./assistant.component";
import { AssistantRoutingModule } from "./assistant.routing";
import { SharedModule } from "../shared/shared.module";
import { ReactiveFormsModule } from "@angular/forms";
import { AssistantResultCardComponent } from "./components/assistant-result-card/assistant-result-card.component";

@NgModule({
  declarations: [
    AssistantComponent, 
    AssistantResultCardComponent
  ],
  imports: [
    CommonModule,
    AssistantRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ]
})
export class AssistantModule {}
