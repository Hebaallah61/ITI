import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { Compo1Component } from './compo1/compo1.component';
import { Compo2Component } from './compo2/compo2.component';

@NgModule({
  declarations: [
    AppComponent,
    Compo1Component,
    Compo2Component
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
