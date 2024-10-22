import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserService } from './services/user.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { CustomerServService } from './components/Customer/serv/customer-serv.service';
import { AdminServService } from './components/Admin/ser/admin-serv.service';
import { DashboardServService } from './components/Admin/com/dashboard/ser/dashboard-serv.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers :[UserService,CustomerServService,AdminServService,DashboardServService]
})
export class AppComponent {
  title = 'BookBorrowingLibrary';
}
