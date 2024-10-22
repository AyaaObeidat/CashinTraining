import { TestBed } from '@angular/core/testing';

import { AdminServService } from './admin-serv.service';

describe('AdminServService', () => {
  let service: AdminServService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminServService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
