import { TestBed } from '@angular/core/testing';

import { BookServService } from './book-serv.service';

describe('DashboardServService', () => {
  let service: BookServService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookServService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
