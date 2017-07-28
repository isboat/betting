import { Component, OnInit } from '@angular/core';
import { BetslipsService } from '../services/betslips.service';

@Component({
  selector: 'app-betslip',
  templateUrl: './betslip.component.html',
  styleUrls: ['./betslip.component.css']
})
export class BetslipComponent implements OnInit {
  
  slips: any[] = [];
  noSlipMsg: string;

  constructor(private betslipsService: BetslipsService) {
    
    this.getSlips();
  }

  deleteSlipItem(slipItem: any){
    this.betslipsService.deleteSlipItem(slipItem.Id);
    this.getSlips();
  }

  getSlips() {
    this.slips = this.betslipsService.getSlips();
    
    if(!this.slips.length){
      this.noSlipMsg = "You've no slips yet."
    }
  }
  ngOnInit() {
  }

}
