import { RegisteredCustomersService } from './components/Admin/com/dashboard/ser/customer-ser/registered-customers.service';
import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { UserService } from './services/user.service';
import { HttpClientModule } from '@angular/common/http';
import { CustomerServService } from './components/Customer/serv/customer-serv.service';
import { AdminServService } from './components/Admin/ser/admin-serv.service';
import { BookServService } from './components/Admin/com/dashboard/ser/book-ser/book-serv.service';
import { BorrRetReqService } from './components/Admin/com/dashboard/ser/Borr-Ret-Reqs-ser/borr-ret-req.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers :[UserService,CustomerServService,AdminServService,BookServService,RegisteredCustomersService,BorrRetReqService]
})
export class AppComponent {
  title = 'BookBorrowingLibrary';
}
