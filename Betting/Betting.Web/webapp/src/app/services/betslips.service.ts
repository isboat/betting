import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
//import { SelectionModel} from './../viewmodels/selection.viewmodel';

@Injectable()
export class BetslipsService {

  private slips: any[] = [];
  
  private subject: Subject<number> = new Subject<number>();

  constructor() { }

  getSlips(){
    return this.slips;
  }

  deleteSlipItem(id: string){
    for (var index = 0; index < this.slips.length; index++) {
      var element = this.slips[index];
      if (element.Id === id) {
        this.slips.splice(index, 1);
        break;
      }
    }

    this.notifySlipCounterListeners();
  }

  addBetSlipItem(selection: any){
    this.slips.push(selection);
    
    this.notifySlipCounterListeners();
  }

  notifySlipCounterListeners() {
    this.subject.next(this.slips.length);
  }

  getBetSlipCount(): Observable<number> {
    return this.subject.asObservable();
  }

}
