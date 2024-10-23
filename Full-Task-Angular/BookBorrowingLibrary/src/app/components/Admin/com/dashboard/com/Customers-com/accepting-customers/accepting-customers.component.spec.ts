import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptingCustomersComponent } from './accepting-customers.component';

describe('AcceptingCustomersComponent', () => {
  let component: AcceptingCustomersComponent;
  let fixture: ComponentFixture<AcceptingCustomersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AcceptingCustomersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AcceptingCustomersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
