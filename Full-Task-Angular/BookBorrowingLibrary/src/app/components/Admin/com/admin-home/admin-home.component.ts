import { Router } from '@angular/router';
import { AdminServService } from './../../ser/admin-serv.service';
import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { AdminHeaderComponent } from "../admin-header/admin-header.component";
import { AdminDashboardComponent } from "../dashboard/admin-dashboard/admin-dashboard.component";
import { AllBooksComponent } from "../dashboard/com/Books-com/all-books/all-books.component";

@Component({
  selector: 'app-admin-home',
  standalone: true,
  imports: [AdminHeaderComponent, AdminDashboardComponent, AllBooksComponent],
  templateUrl: './admin-home.component.html',
  styleUrl: './admin-home.component.css',
})
export class AdminHomeComponent implements OnInit,OnDestroy{
  adminData: any;
  constructor(
    private adminServService: AdminServService,
    private router: Router,
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document
  ) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras.state) {
      this.adminData = navigation.extras.state['user'];
      this.adminServService.SetAdminData(this.adminData);
      console.log(this.adminData);
      
    }
  }
  ngOnInit(): void {
    this.render.setStyle(this.document.body,'backgroundColor','#313b31');
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body,'backgroundColor');
  }
}
