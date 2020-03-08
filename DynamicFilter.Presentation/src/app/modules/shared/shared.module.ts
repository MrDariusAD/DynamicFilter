import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardComponent } from './card/card.component';
import { FullMaterialModule } from 'src/app/full-material-module';
import { AttributeInCardOutputComponent } from './attribute-in-card-output/attribute-in-card-output.component';


@NgModule({
  declarations: [
    CardComponent,
    AttributeInCardOutputComponent
  ],
  imports: [
    CommonModule,
    FullMaterialModule
  ],
  exports: [
    CardComponent,
    FullMaterialModule,
    AttributeInCardOutputComponent
  ]
})
export class SharedModule { }
