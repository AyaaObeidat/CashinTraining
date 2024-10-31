import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';
import { HeaderComponent } from '../../../../../../header/header.component';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { CommonModule, DOCUMENT } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BookServService } from '../../../ser/book-ser/book-serv.service';

@Component({
  selector: 'app-new-book',
  standalone: true,
  imports: [AdminDashboardComponent, HeaderComponent, AdminHeaderComponent,CommonModule,FormsModule],
  templateUrl: './new-book.component.html',
  styleUrl: './new-book.component.css',
})
export class NewBookComponent implements OnInit, OnDestroy {
  book = {
    title: '',
    description: '',
    author: '',
    publisher: '',
    publicationYear: '',
    numberOfAvailableCopies: 0,
    totalNumberOfCopies: 0,
  };
  constructor(
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document,
    private bookService : BookServService
  ) {}
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
  AddNewBook(){
    this.bookService.AddNewBook(this.book).subscribe(
      res => {},
      err => {}
    );
    this.book = {
      title: '',
      description: '',
      author: '',
      publisher: '',
      publicationYear: '',
      numberOfAvailableCopies: 0,
      totalNumberOfCopies: 0,
    };
  }
}
