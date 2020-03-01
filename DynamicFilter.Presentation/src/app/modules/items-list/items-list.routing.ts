import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ItemsListComponent } from './items-list.component';


const routes: Routes = [
  {path: 'view', component: ItemsListComponent},
  {path: '**', redirectTo: 'view', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemsListRoutingModule { }
