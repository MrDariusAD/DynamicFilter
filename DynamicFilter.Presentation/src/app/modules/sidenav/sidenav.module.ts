import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav.component';
import { SidenavItemComponent } from './sidenav-item/sidenav-item.component';
import { FullMaterialModule } from 'src/app/full-material-module';



@NgModule({
  declarations: [
    SidenavComponent,
    SidenavItemComponent,
  ],
  imports: [
    CommonModule,
    FullMaterialModule
  ],
  exports: [
    SidenavComponent,
    SidenavItemComponent,
  ]
})
export class SidenavModule { }
