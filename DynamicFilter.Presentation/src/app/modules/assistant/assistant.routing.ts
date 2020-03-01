import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssistantComponent } from './assistant.component';


const routes: Routes = [
  {path: 'view', component: AssistantComponent},
  {path: '**', redirectTo: 'view', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssistantRoutingModule { }
