import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { ItemsListComponent } from './items-list.component';
import { ItemsListRoutingModule } from './items-list.routing';
import { FullMaterialModule } from 'src/app/full-material-module';



@NgModule({
  declarations: [
    ItemsListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ItemsListRoutingModule,
    FullMaterialModule
  ],
  exports:[
    ItemsListComponent
  ]
})
export class ItemsListModule { }
