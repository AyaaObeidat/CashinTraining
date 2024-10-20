import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { CommonModule, DOCUMENT } from '@angular/common';
import { CustomerHeaderComponent } from '../customer-header/customer-header.component';
import { CustomerServService } from '../../serv/customer-serv.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CustomerHeaderComponent , CommonModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'], // Fixed typo from styleUrl to styleUrls
})
export class CartComponent implements OnInit, OnDestroy {
  customer: any;
  customerBook: any = {}
  isActive = false;
  constructor(
    @Inject(DOCUMENT) private document: Document,
    private render: Renderer2,
    private customerService: CustomerServService
  ) {
    debugger
    this.customer = this.customerService.GetCustomerData();
    this.customerBook = this.customer.book;
    if(this.customerBook != null) this.isActive = true;
  }

  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
  }

  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }

  ReturnBook(){
    this.isActive=false;
  }
}
