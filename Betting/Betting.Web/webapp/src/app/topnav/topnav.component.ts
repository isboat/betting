import { Component, OnInit, OnDestroy } from '@angular/core';
import { BetslipsService } from '../services/betslips.service';

@Component({
  selector: 'topnav',
  templateUrl: './topnav.component.html',
  styleUrls: ['./topnav.component.css']
})
export class TopnavComponent implements OnInit {

  navItems: any[];
  slipsBadge: number;

  constructor(private _betSlipsService: BetslipsService) { 
    this.navItems = [];
  }

  ngOnInit() {
    this.navItems.push({ name: 'Home', url: ''});
    this.navItems.push({ name: 'Link', url: '/link'});
    this.navItems.push({ name: 'Home', url: ''});
    
    this._betSlipsService.getBetSlipCount().subscribe(count => {
      console.log(count);
      this.slipsBadge = count;
    })
  }

  ngOnDestroy(){
    //this._betSlipsService.getBetSlipCount().unsubscribe();
  }
}
