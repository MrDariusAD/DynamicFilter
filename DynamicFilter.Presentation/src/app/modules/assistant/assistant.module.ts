import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssistantComponent } from './assistant.component';
import { AssistantRoutingModule } from './assistant.routing';



@NgModule({
  declarations: [AssistantComponent],
  imports: [
    CommonModule,
    AssistantRoutingModule
  ]
})
export class AssistantModule { }
