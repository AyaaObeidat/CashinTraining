import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookReturningRequestsComponent } from './book-returning-requests.component';

describe('BookReturningRequestsComponent', () => {
  let component: BookReturningRequestsComponent;
  let fixture: ComponentFixture<BookReturningRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookReturningRequestsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BookReturningRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
