import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HttpReqLoaderComponent } from './http-req-loader.component';

describe('HttpReqLoaderComponent', () => {
  let component: HttpReqLoaderComponent;
  let fixture: ComponentFixture<HttpReqLoaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HttpReqLoaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HttpReqLoaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
