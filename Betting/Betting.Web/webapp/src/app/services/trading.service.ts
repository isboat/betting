import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class TradingService {
  private http: Http;

  constructor(http: Http) {
    this.http = http;
   }

  getPopularPanels(){
    return this.http.get("/TradingContent/GetPopularPanels").map(res => res.json());    
  }
}
