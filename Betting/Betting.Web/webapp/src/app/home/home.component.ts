import { Component, OnInit } from '@angular/core';
import { fadeInAnimation } from '../animations/index';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  animations: [fadeInAnimation],
  styleUrls: ['./home.component.css'],
  host: { '[@fadeInAnimation]': 'true'}
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
