import { TestBed } from '@angular/core/testing';

import { BorrRetReqService } from './borr-ret-req.service';

describe('BorrRetReqService', () => {
  let service: BorrRetReqService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BorrRetReqService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
