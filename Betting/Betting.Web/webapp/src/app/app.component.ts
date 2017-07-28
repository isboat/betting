import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private betSlipCount: number;

  constructor(){
    this.betSlipCount = 2;
  }

  betCount(){
    this.betSlipCount = this.betSlipCount + 1;
  }
}
