import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';

import { HttpReqLoaderService } from '../services/http-req-loader.service';

@Component({
  selector: 'app-http-req-loader',
  templateUrl: './http-req-loader.component.html',
  styleUrls: ['./http-req-loader.component.css']
})
export class HttpReqLoaderComponent implements OnInit {

  show = false;
  private subscription: Subscription;

  constructor(private loaderService:HttpReqLoaderService) { }

  ngOnInit() {
    
    this.subscription = this.loaderService.loaderState.subscribe((state: any) => {
      this.show = state.show;
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
