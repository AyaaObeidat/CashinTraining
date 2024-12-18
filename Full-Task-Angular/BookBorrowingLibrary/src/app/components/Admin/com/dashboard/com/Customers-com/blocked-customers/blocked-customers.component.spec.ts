import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlockedCustomersComponent } from './blocked-customers.component';

describe('BlockedCustomersComponent', () => {
  let component: BlockedCustomersComponent;
  let fixture: ComponentFixture<BlockedCustomersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BlockedCustomersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BlockedCustomersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
