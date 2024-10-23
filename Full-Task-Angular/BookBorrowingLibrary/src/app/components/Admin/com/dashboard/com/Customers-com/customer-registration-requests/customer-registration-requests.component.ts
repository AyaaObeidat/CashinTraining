import { RegisteredCustomersService } from './../../../ser/customer-ser/registered-customers.service';
import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { CommonModule, DOCUMENT } from '@angular/common';
import { BookServService } from '../../../ser/book-ser/book-serv.service';
import { error } from 'console';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-customer-registration-requests',
  standalone: true,
  imports: [AdminDashboardComponent, AdminHeaderComponent, CommonModule,RouterOutlet,RouterLink,RouterLinkActive],
  templateUrl: './customer-registration-requests.component.html',
  styleUrl: './customer-registration-requests.component.css',
})
export class CustomerRegistrationRequestsComponent
  implements OnInit, OnDestroy
{
  allPendingCustomers: any;
  constructor(
    private render: Renderer2,
    private registeredCustomersService: RegisteredCustomersService,
    @Inject(DOCUMENT) private document: Document
  ) {}
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
    this.registeredCustomersService
      .GetAllCustomerRegistrationRequests()
      .subscribe(
        (res) => (this.allPendingCustomers = res),
        (err) => console.log('Faild')
      );
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
  AcceptCustomer(customer: any) {
    this.registeredCustomersService.AcceptCustomer({ id: customer?.id }).subscribe(
      res => alert('successfuly accepting'),
      err => alert('faild')
    );
  }
  RejectCustomer(customer: any) {
    this.registeredCustomersService.RejectCustomer({id : customer?.id}).subscribe(
      res => alert('successfuly'),
      err => alert('faild')
    );
  }
}
