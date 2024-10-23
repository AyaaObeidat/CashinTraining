import { CommonModule, DOCUMENT } from '@angular/common';
import { Component, Inject, Renderer2 } from '@angular/core';
import { RegisteredCustomersService } from '../../../ser/customer-ser/registered-customers.service';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-blocked-customers',
  standalone: true,
  imports: [CommonModule,AdminHeaderComponent,AdminDashboardComponent,RouterOutlet,RouterLink,RouterLinkActive],
  templateUrl: './blocked-customers.component.html',
  styleUrl: './blocked-customers.component.css'
})
export class BlockedCustomersComponent {
  allBlockedCustomers : any;
  constructor(
    private render: Renderer2,
    private registeredCustomersService: RegisteredCustomersService,
    @Inject(DOCUMENT) private document: Document
  ) {}
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
    this.registeredCustomersService
      .GetAllBlockedCustomers()
      .subscribe(
        (res) => (this.allBlockedCustomers = res),
        (err) => console.log('Faild')
      );
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
  UnblockCustomer(customer : any){
    this.registeredCustomersService.UnblockCustomer({id:customer?.id}).subscribe(
      (res) => alert('Successfuly UnBlock Customer'),
      (err) => alert('Faild')
    );
  }
}
