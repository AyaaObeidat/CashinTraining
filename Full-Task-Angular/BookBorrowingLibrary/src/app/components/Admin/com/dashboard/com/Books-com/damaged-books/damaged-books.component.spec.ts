import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DamagedBooksComponent } from './damaged-books.component';

describe('DamagedBooksComponent', () => {
  let component: DamagedBooksComponent;
  let fixture: ComponentFixture<DamagedBooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DamagedBooksComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DamagedBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
