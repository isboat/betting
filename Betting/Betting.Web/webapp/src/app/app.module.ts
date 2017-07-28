import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { PopularpanelsComponent } from './popularpanels/popularpanels.component';
import { TopnavComponent } from './topnav/topnav.component';
import { HomeComponent } from './home/home.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { BetslipComponent } from './betslip/betslip.component';
import { HttpReqLoaderComponent } from './http-req-loader/http-req-loader.component';

import { BetslipsService } from './services/betslips.service';
import { HttpReqLoaderService } from './services/http-req-loader.service';

@NgModule({
  declarations: [
    AppComponent,
    PopularpanelsComponent,
    TopnavComponent,
    HomeComponent,
    PagenotfoundComponent,
    BetslipComponent,
    HttpReqLoaderComponent
  ],
  imports: [
    BrowserModule, 
    HttpModule, 
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [HttpReqLoaderService, BetslipsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
