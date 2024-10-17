import { TestBed } from '@angular/core/testing';

import { CustomerServService } from './customer-serv.service';

describe('CustomerServService', () => {
  let service: CustomerServService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomerServService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
