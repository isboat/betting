import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
//import { SelectionModel} from './../viewmodels/selection.viewmodel';

@Injectable()
export class BetslipsService {

  private slips: any[] = [];
  
  private subject: Subject<number> = new Subject<number>();

  constructor() { }

  updateBetSlips(selection: any){
    this.slips.push(selection);
    this.subject.next(this.slips.length);
  }

  getBetSlipCount(): Observable<number> {
    return this.subject.asObservable();
  }

}
