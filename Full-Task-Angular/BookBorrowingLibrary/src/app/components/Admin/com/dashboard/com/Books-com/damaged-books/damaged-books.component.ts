import { CommonModule, DOCUMENT } from '@angular/common';
import { BookServService } from './../../../ser/book-ser/book-serv.service';
import { Component, Inject, Renderer2 } from '@angular/core';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-damaged-books',
  standalone: true,
  imports: [AdminHeaderComponent,AdminDashboardComponent,RouterOutlet,RouterLink,RouterLinkActive,CommonModule],
  templateUrl: './damaged-books.component.html',
  styleUrl: './damaged-books.component.css'
})
export class DamagedBooksComponent {
  allDamagedBooks:any;
  constructor(
    private render: Renderer2,
    private bookServService: BookServService,
    @Inject(DOCUMENT) private document: Document
  ) {}
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
    this.bookServService
      .GetAllDamagedBooks()
      .subscribe(
        (res) => (this.allDamagedBooks = res),
        (err) => console.log('Faild')
      );
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
  Repair(book:any){
    this.bookServService.Repair({id:book?.id}).subscribe(
      res => {},
      err => {}
    );
  }
}
