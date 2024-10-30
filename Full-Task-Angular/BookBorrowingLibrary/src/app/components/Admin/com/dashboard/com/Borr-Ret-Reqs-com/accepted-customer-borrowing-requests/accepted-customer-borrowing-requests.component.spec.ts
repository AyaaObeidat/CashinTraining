import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptedCustomerBorrowingRequestsComponent } from './accepted-customer-borrowing-requests.component';

describe('AcceptedCustomerBorrowingRequestsComponent', () => {
  let component: AcceptedCustomerBorrowingRequestsComponent;
  let fixture: ComponentFixture<AcceptedCustomerBorrowingRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AcceptedCustomerBorrowingRequestsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AcceptedCustomerBorrowingRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
