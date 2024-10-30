import { CommonModule, DatePipe, DOCUMENT } from '@angular/common';
import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';
import { BorrRetReqService } from '../../../ser/Borr-Ret-Reqs-ser/borr-ret-req.service';

@Component({
  selector: 'app-accepted-customer-borrowing-requests',
  standalone: true,
  imports: [
    AdminHeaderComponent,
    AdminDashboardComponent,
    CommonModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    DatePipe,
  ],
  templateUrl: './accepted-customer-borrowing-requests.component.html',
  styleUrl: './accepted-customer-borrowing-requests.component.css',
})
export class AcceptedCustomerBorrowingRequestsComponent
  implements OnInit, OnDestroy
{
  allAcceptedRequests: any;
  constructor(
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document,
    private requestService: BorrRetReqService
  ) {}
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
    this.requestService.GetAllAcceptedCustomerBorrowingRequsets().subscribe(
      (res) => (this.allAcceptedRequests = res),
      (err) => console.log('Faild')
    );
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
}
