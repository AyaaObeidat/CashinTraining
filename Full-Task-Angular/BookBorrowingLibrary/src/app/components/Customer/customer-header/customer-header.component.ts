import { Component, Input } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CustomerServService } from '../customerServ/customer-serv.service';

@Component({
  selector: 'app-customer-header',
  standalone: true,
  imports: [RouterOutlet,RouterLink,RouterLinkActive],
  templateUrl: './customer-header.component.html',
  styleUrl: './customer-header.component.css'
})
export class CustomerHeaderComponent {
  customer : any;
  constructor(private customerServ : CustomerServService)
  {
    this.customer = this.customerServ.GetCustomerData();
  }
}
