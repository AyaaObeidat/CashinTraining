import { Component, OnInit } from '@angular/core';
import { CreateService } from '../../services/createService/create.service';
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [HeaderComponent, CommonModule, RouterOutlet, FormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css',
})
export class CreateComponent {
  user = {
    tripleName: '',
    email: '',
    password: '',
    gender: Number,
  };

  constructor(private _createService: CreateService, private _router: Router) {}

  Create(): void {
    if (
      this.user.tripleName &&
      this.user.email &&
      this.user.password &&
      this.user.gender !== null
    ) {
      this._createService.Create(this.user).subscribe(
        (res) => {
          this._router.navigate(['login']);
        },
        (err) => {
          alert('Error creating user');
        }
      );
    }
  }
}
