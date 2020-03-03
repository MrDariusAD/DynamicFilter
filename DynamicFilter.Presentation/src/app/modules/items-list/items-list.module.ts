import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { ItemsListComponent } from './items-list.component';
import { ItemsListRoutingModule } from './items-list.routing';
import { FullMaterialModule } from 'src/app/full-material-module';
import { FilteredSearchComponent } from './components/filtered-search/filtered-search.component';
import { ItemCardComponent } from './components/item-card/item-card.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ItemsListComponent,
    FilteredSearchComponent,
    ItemCardComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ItemsListRoutingModule,
    ReactiveFormsModule
  ],
  exports:[
    ItemsListComponent
  ],
  providers: []
})
export class ItemsListModule { }
