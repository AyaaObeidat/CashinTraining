import { error } from 'console';
import { BookServService } from '../../../ser/book-ser/book-serv.service';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-all-books',
  standalone: true,
  imports: [CommonModule,RouterOutlet,RouterLink,RouterLinkActive],
  templateUrl: './all-books.component.html',
  styleUrl: './all-books.component.css',
})
export class AllBooksComponent implements OnInit{
  allBooks: any;
  constructor(private bookService: BookServService,private router:Router) {}
  ngOnInit(): void {
    this.bookService.GetAllBooks().subscribe(
      res => this.allBooks = res,
      err => console.log("not found any book"),
    );
  }
  ViewBook(book:any)
  {
    this.router.navigate(['/viewBook'],{state:{viewBook:book}});
  }
  EditBook(book:any)
  {
    this.router.navigate(['/editBook'],{state:{editBook:book}});
  }
  AddNewBook()
  {
    this.router.navigate(['/newBook']);
  }
}
