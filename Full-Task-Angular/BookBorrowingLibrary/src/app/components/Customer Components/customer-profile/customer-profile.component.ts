import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from "../../header/header.component";
import { CustomerHeaderComponent } from "../customer-header/customer-header.component";

@Component({
  selector: 'app-customer-profile',
  standalone: true,
  templateUrl: './customer-profile.component.html',
  styleUrls: ['./customer-profile.component.css'],
  imports: [CommonModule, HeaderComponent, CustomerHeaderComponent , RouterOutlet]
})
export class CustomerProfileComponent {
  customer: any;
  constructor(private router : Router)
  {
    const navigation = this.router.getCurrentNavigation();
    if(navigation?.extras.state)
    {
      this.customer = navigation.extras.state['user'];
    }
  }
}
