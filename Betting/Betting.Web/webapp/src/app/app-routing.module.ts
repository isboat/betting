import { NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { BetslipComponent } from './betslip/betslip.component';

const appRoutes = [
  { path: '', component:HomeComponent},
  { path: 'betslip', component: BetslipComponent},
  { path: '**', component: PagenotfoundComponent }
]

@NgModule({
    imports: [ RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}