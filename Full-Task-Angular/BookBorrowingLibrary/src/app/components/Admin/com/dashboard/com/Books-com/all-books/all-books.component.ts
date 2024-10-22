import { error } from 'console';
import { DashboardServService } from '../../../ser/dashboard-serv.service';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-all-books',
  standalone: true,
  imports: [CommonModule,RouterOutlet,RouterLink],
  templateUrl: './all-books.component.html',
  styleUrl: './all-books.component.css',
})
export class AllBooksComponent implements OnInit{
  allBooks: any;
  constructor(private dashboardService: DashboardServService,private router:Router) {}
  ngOnInit(): void {
    this.dashboardService.GetAllBooks().subscribe(
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
}
