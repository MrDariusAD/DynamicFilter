import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardComponent } from './card/card.component';
import { FullMaterialModule } from 'src/app/full-material-module';


@NgModule({
  declarations: [
    CardComponent
  ],
  imports: [
    CommonModule,
    FullMaterialModule
  ],
  exports: [
    CardComponent,
    FullMaterialModule
  ]
})
export class SharedModule { }
