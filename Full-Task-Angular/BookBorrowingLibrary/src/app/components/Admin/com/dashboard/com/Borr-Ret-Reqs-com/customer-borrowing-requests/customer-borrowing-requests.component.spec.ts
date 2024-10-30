import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerBorrowingRequestsComponent } from './customer-borrowing-requests.component';

describe('CustomerBorrowingRequestsComponent', () => {
  let component: CustomerBorrowingRequestsComponent;
  let fixture: ComponentFixture<CustomerBorrowingRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerBorrowingRequestsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CustomerBorrowingRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
