import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './Routing/home/home.component';
import { HeaderComponent } from './Routing/header/header.component';
import { StudentsComponent } from './Routing/students/students.component';
import { DetailsComponent } from './Routing/details/details.component';
import { ErrorComponent } from './Routing/error/error.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    StudentsComponent,
    DetailsComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    // FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(
      [
        {path:"",component:HomeComponent},
        {path:"home",component:HomeComponent},
        {path:"students",component:StudentsComponent},
        {path:"error",component:ErrorComponent},
        {path:"details/:id",component:DetailsComponent},
        {path:"**",component:ErrorComponent},
      ]
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
