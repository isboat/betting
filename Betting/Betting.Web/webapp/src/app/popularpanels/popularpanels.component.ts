import { Component, OnInit } from '@angular/core';
import { TradingService } from '../services/trading.service';
import { BetslipsService } from '../services/betslips.service';

@Component({
  selector: 'popularpanels',
  templateUrl: './popularpanels.component.html',
  styleUrls: ['./popularpanels.component.css'],
  providers: [TradingService]
})
export class PopularpanelsComponent implements OnInit {

  panels: any[];

  constructor(private _tradingService: TradingService, private _betslipsService: BetslipsService) {
    this._tradingService.getPopularPanels().subscribe(
      data => this.panels = data.Panels,
      error => console.log(error)
    )
  }

  ngOnInit() {
  }

  addToBetSlip(selection: any){
    this._betslipsService.addBetSlipItem(selection);
  }
}
