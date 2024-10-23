import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerRegistrationRequestsComponent } from './customer-registration-requests.component';

describe('CustomerRegistrationRequestsComponent', () => {
  let component: CustomerRegistrationRequestsComponent;
  let fixture: ComponentFixture<CustomerRegistrationRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerRegistrationRequestsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CustomerRegistrationRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
