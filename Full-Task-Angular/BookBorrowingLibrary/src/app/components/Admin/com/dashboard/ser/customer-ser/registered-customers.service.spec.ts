import { TestBed } from '@angular/core/testing';

import { RegisteredCustomersService } from './registered-customers.service';

describe('RegisteredCustomersService', () => {
  let service: RegisteredCustomersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegisteredCustomersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
