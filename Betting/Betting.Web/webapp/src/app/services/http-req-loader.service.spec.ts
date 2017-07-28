import { TestBed, inject } from '@angular/core/testing';

import { HttpReqLoaderService } from './http-req-loader.service';

describe('HttpReqLoaderService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpReqLoaderService]
    });
  });

  it('should be created', inject([HttpReqLoaderService], (service: HttpReqLoaderService) => {
    expect(service).toBeTruthy();
  }));
});
