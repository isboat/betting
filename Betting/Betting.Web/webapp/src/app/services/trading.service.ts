import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { HttpReqLoaderService } from './http-req-loader.service';

@Injectable()
export class TradingService {
  private http: Http;

  constructor(http: Http, private loader: HttpReqLoaderService) {
    this.http = http;
   }

  getPopularPanels(){
    this.loader.show();

    return this.http.get("/TradingContent/GetPopularPanels").map(
      (res:any) => {
        this.loader.hide();
        return res.json()
      })    
  }
}
