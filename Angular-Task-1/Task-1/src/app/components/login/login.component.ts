import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginService } from '../../services/loginService/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginData = {
    email: '',
    password: '',
  };
  user: any;
  constructor(private _loginService: LoginService, private _router: Router) {}

  Login() {
    this._loginService.getUserData(this.loginData).subscribe(
      (res) => {
        this._router.navigate(['profile']);
      },

      (err) => {
        alert('Faild Login');
      }
    );
  }
}
