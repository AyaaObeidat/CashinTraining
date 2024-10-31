import { CommonModule, DatePipe, DOCUMENT } from '@angular/common';
import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';
import { BorrRetReqService } from '../../../ser/Borr-Ret-Reqs-ser/borr-ret-req.service';

@Component({
  selector: 'app-book-returning-requests',
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
  templateUrl: './book-returning-requests.component.html',
  styleUrl: './book-returning-requests.component.css',
})
export class BookReturningRequestsComponent implements OnInit, OnDestroy {
  allBookReturnedRequests: any;
  constructor(
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document,
    private requestService: BorrRetReqService
  ) {}
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
    this.requestService.GetAllBookReturnedRequsets().subscribe(
      (res) => (this.allBookReturnedRequests = res),
      (err) => console.log('Faild')
    );
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
  SetNonCorruptBookStatus(request: any) {
    this.requestService.SetNonCorruptBookStatus({ id: request?.id , bookStatus : 0}).subscribe(
      (res) => {},
      (err) => {}
    );
  }

  SetDamagedBookStatus(request: any) {
    this.requestService.SetDamagedBookStatus({ id: request?.id , bookStatus : 1}).subscribe(
      (res) => {},
      (err) => {}
    );
  }
}
