import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { PhaseFmShopModule } from './phase-fm-shop/phase-fm-shop.module';
import { PhaseFmRadioModule } from './phase-fm-radio/phase-fm-radio.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PhaseFmShopModule,
    PhaseFmRadioModule,
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [],
  bootstrap:[AppComponent]
})
export class AppModule { }
