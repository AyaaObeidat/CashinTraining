import { Component, OnInit } from '@angular/core';
import { CreateService } from '../../services/createService/create.service';
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
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

  private _createService: CreateService;
  constructor(createService: CreateService) {
    this._createService = createService;
  }

  Create(): void {
    if (
      this.user.tripleName &&
      this.user.email &&
      this.user.password &&
      this.user.gender !== null
    ) {
      this._createService.Create(this.user).subscribe(
        (res) => {
          alert('User created successfully');
        },
        (err) => {
          alert('Error creating user');
        }
      );
    }
  }
}
