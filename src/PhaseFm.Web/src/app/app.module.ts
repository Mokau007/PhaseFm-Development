import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PhaseFmShopModule } from './phase-fm-shop/phase-fm-shop.module';
import { PhaseFmRadioModule } from './phase-fm-radio/phase-fm-radio.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PhaseFmShopModule,
    PhaseFmRadioModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
