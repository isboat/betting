import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { PopularpanelsComponent } from './popularpanels/popularpanels.component';
import { TopnavComponent } from './topnav/topnav.component';
import { HomeComponent } from './home/home.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';

import { BetslipsService } from './services/betslips.service';
import { BetslipComponent } from './betslip/betslip.component';

const appRoutes = [
  { path: '', component:HomeComponent},
  { path: 'betslip', component: BetslipComponent},
  { path: '**', component: PagenotfoundComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    PopularpanelsComponent,
    TopnavComponent,
    HomeComponent,
    PagenotfoundComponent,
    BetslipComponent
  ],
  imports: [
    BrowserModule, HttpModule, RouterModule.forRoot(appRoutes)
  ],
  providers: [BetslipsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
