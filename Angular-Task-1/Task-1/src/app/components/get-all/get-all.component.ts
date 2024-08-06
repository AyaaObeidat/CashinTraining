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

  constructor(private getAllService: GetAllService) { }

  ngOnInit(): void {
    this.getAllService.getAll().subscribe(
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
