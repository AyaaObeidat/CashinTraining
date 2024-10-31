import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';
import { CommonModule, DatePipe, DOCUMENT } from '@angular/common';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { BorrRetReqService } from '../../../ser/Borr-Ret-Reqs-ser/borr-ret-req.service';

@Component({
  selector: 'app-customer-borrowing-requests',
  standalone: true,
  imports: [
    AdminHeaderComponent,
    AdminDashboardComponent,
    CommonModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    DatePipe
  ],
  templateUrl: './customer-borrowing-requests.component.html',
  styleUrl: './customer-borrowing-requests.component.css',
})
export class CustomerBorrowingRequestsComponent implements OnInit,OnDestroy{
  allPendingRequests:any;
  constructor(
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document,
    private requestService : BorrRetReqService,
    private router : Router
  ) {}
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
    this.requestService.GetAllCustomerBorrowingRequsets().subscribe(
      res => this.allPendingRequests=res,
      err => console.log('Faild')
    );
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
  AcceptRequest(request:any){
  this.requestService.AcceptRequest({id:request?.id}).subscribe(
    res => {},
    err => {}
  );
  }
  RejectRequest(request:any){
    this.requestService.RejectRequest({id:request?.id}).subscribe(
      res =>  {},
      err => {}
    );
  }
}
