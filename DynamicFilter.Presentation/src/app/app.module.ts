import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent, ActivateLicenseDialog } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SidenavComponent } from './modules/sidenav/sidenav.component';
import { FullMaterialModule } from './full-material-module';
import { SidenavItemComponent } from './modules/sidenav/sidenav-item/sidenav-item.component';
import { ApiService } from './services/api.service';
import { HttpClientModule } from '@angular/common/http';
import { ItemsListModule } from './modules/items-list/items-list.module';
import { SharedModule } from './modules/shared/shared.module';
import { SidenavModule } from './modules/sidenav/sidenav.module';
import { AssistantModule } from './modules/assistant/assistant.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    ActivateLicenseDialog
  ],
  imports: [
    FullMaterialModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ItemsListModule,
    SharedModule,
    SidenavModule,
    AssistantModule,
    FormsModule 
  ],
  providers: [
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
