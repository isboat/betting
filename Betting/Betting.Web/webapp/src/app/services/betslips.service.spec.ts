import { TestBed, inject } from '@angular/core/testing';

import { BetslipsService } from './betslips.service';

describe('BetslipsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BetslipsService]
    });
  });

  it('should be created', inject([BetslipsService], (service: BetslipsService) => {
    expect(service).toBeTruthy();
  }));
});
