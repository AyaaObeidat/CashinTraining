import { Component, OnInit } from '@angular/core';
import { GetAllService } from '../../services/getAllService/get-all.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-get-all',
  templateUrl: './get-all.component.html',
  styleUrls: ['./get-all.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class GetAllComponent implements OnInit {
  users: any[] = [];

  constructor(private _getAllService: GetAllService, private _router: Router) {}

  ngOnInit(): void {
    this._getAllService.getAll().subscribe(
      (res) => {
        this.users = res;
      },
      (err) => {
        console.error('Error fetching users:', err);
      }
    );
  }

  viewUser(user: any): void {
    this._router.navigate(['/view', user.id]);
  }

  UpdateUser(user: any): void {
    this._router.navigate(['/update', user.id]);
  }
}
