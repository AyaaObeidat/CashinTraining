import { CommonModule, DOCUMENT } from '@angular/common';
import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { CustomerHeaderComponent } from '../customer-header/customer-header.component';
import { CustomerServService } from '../../serv/customer-serv.service';
@Component({
  selector: 'app-customer-home',
  standalone: true,
  templateUrl: './customer-home.component.html',
  styleUrls: ['./customer-home.component.css'],
  imports: [CommonModule, CustomerHeaderComponent, RouterOutlet, RouterLink],
})
export class CustomerHomeComponent implements OnInit, OnDestroy {
  customer: any = {};
  allBooks: any[] = [];
  readRules = false;
  canBorrow = false;
  cannotBorrow = false;
  constructor(
    private router: Router,
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document,
    private customerServ: CustomerServService
  ) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras.state) {
      this.customer = navigation.extras.state['user'];
      this.customerServ.SetCustomerData(this.customer);
      console.log(this.customer);
    }
  }
  ngOnInit() {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
    this.customerServ.GetAllBooks().subscribe(
      (res) => (this.allBooks = res),
      (err) => console.log('cannot found any book')
    );
  }
  ngOnDestroy() {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
  BorrowBook(book: any) {
    this.customerServ
      .BorrowBook({ userId: this.customer?.id, bookId: book?.id })
      .subscribe(
        (res) => this.canBorrow=true,
        (err) => this.cannotBorrow = true
      );
  }
  ReadRules() {
    this.readRules = true;
  }
}
