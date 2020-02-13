import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ItemsListComponent } from './components/items-list/items-list.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { FullMaterialModule } from './full-material-module';
import { SidenavItemComponent } from './components/sidenav/sidenav-item/sidenav-item.component';


@NgModule({
  declarations: [
    AppComponent,
    ItemsListComponent,
    SidenavComponent,
    SidenavItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FullMaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
