import { Router } from '@angular/router';
import { routes } from './../../../../../../../app.routes';
import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-view-book',
  standalone: true,
  imports: [AdminHeaderComponent, AdminDashboardComponent],
  templateUrl: './view-book.component.html',
  styleUrl: './view-book.component.css',
})
export class ViewBookComponent implements OnInit,OnDestroy{
  bookData: any;
  constructor (
    private router: Router,
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document
  ) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras.state) {
      this.bookData = navigation.extras.state['viewBook'];
    }
  }
  ngOnInit(): void {
    this.render.setStyle(this.document.body,'backgroundColor','#313b31');
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body,'backgroundColor');
  }
}
