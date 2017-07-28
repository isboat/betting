import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PopularpanelsComponent } from './popularpanels.component';

describe('PopularpanelsComponent', () => {
  let component: PopularpanelsComponent;
  let fixture: ComponentFixture<PopularpanelsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PopularpanelsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PopularpanelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
