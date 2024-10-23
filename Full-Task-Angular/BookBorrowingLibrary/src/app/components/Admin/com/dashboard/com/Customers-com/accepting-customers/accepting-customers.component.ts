import { Component, Inject, Renderer2 } from '@angular/core';
import { AdminDashboardComponent } from "../../../admin-dashboard/admin-dashboard.component";
import { AdminHeaderComponent } from "../../../../admin-header/admin-header.component";
import { CommonModule, DOCUMENT } from '@angular/common';
import { RegisteredCustomersService } from '../../../ser/customer-ser/registered-customers.service';

@Component({
  selector: 'app-accepting-customers',
  standalone: true,
  imports: [AdminDashboardComponent, AdminHeaderComponent,CommonModule],
  templateUrl: './accepting-customers.component.html',
  styleUrl: './accepting-customers.component.css'
})
export class AcceptingCustomersComponent {
  allAcceptingCustomers : any;
  constructor(
    private render: Renderer2,
    private registeredCustomersService: RegisteredCustomersService,
    @Inject(DOCUMENT) private document: Document
  ) {}
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
    this.registeredCustomersService
      .GetAllAcceptingCustomers()
      .subscribe(
        (res) => (this.allAcceptingCustomers = res),
        (err) => console.log('Faild')
      );
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
}
