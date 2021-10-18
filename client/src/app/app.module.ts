import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { TooltipModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home/home.component';
import { CandidatesComponent } from './candidates/candidates.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { NavComponent } from './nav/nav.component';

@NgModule({
  declarations: [
    AppComponent,
    CandidatesComponent,
    HomeComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    TooltipModule.forRoot(),
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    RouterModule.forRoot([]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
