import { Component, OnInit } from '@angular/core';
import { GetAllService } from '../../services/get-all.service';
import { HeaderComponent } from "../header/header.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-get-all',
  standalone: true,
  imports: [HeaderComponent, CommonModule],
  templateUrl: './get-all.component.html',
  styleUrls: ['./get-all.component.css'] // Corrected to styleUrls
})
export class GetAllComponent implements OnInit {

  users: any[] = [];
  private _getAllService: GetAllService;

  constructor(getAllService: GetAllService) {
    this._getAllService=getAllService;
   }

  ngOnInit(): void {
    this._getAllService.getAll().subscribe(
      res => {
        this.users = res;
        console.log(this.users);
      },
      err => {
        console.error('Error fetching users:', err); // Optional error handling
      }
    );
  }
}
