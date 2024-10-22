import { RouterLink, RouterOutlet } from '@angular/router';
import { AdminServService } from './../../ser/admin-serv.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-header',
  standalone: true,
  imports: [RouterOutlet,RouterLink],
  templateUrl: './admin-header.component.html',
  styleUrl: './admin-header.component.css'
})
export class AdminHeaderComponent {
admin:any;
constructor(private adminServService : AdminServService){
this.admin = this.adminServService.GetAdminData();
}
}
