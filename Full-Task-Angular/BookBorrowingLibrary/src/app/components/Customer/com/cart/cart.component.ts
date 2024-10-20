import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { CommonModule, DOCUMENT } from '@angular/common';
import { CustomerHeaderComponent } from '../customer-header/customer-header.component';
import { CustomerServService } from '../../serv/customer-serv.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CustomerHeaderComponent, CommonModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit, OnDestroy {
  customer: any = {};
  customerBook: any = {};
  haveBook = false;

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2,
    private customerService: CustomerServService
  ) {}

  ngOnInit(): void {
    this.renderer.setStyle(this.document.body, 'backgroundColor', '#313b31');

    // Get customer data
    this.customer = this.customerService.GetCustomerData();
    this.customerBook = this.customer?.book;
    if (this.customerBook !== null) this.haveBook = true;
  }

  ngOnDestroy(): void {
    this.renderer.removeStyle(this.document.body, 'backgroundColor');
  }

  ReturnBook(): void {
    this.customerService
      .ReturnBorrowedBook({
        userId: this.customer?.id,
        bookId: this.customerBook?.id,
      })
      .subscribe(
        (res) => {
          alert('Successful Return');
          this.haveBook = false;
        },
        (err) => {
          alert('Failed Return');
        }
      );
  }
}
