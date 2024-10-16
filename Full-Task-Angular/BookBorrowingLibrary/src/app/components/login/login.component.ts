import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HeaderComponent, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  user = {
    email: "",
    password: ""
  };
  
  UserLoginData: any;

  constructor(private userService: UserService, private router: Router) {}

  GetLoginData() {
    return this.userService.Login(this.user).subscribe(
      res => {
        this.UserLoginData = res;
        if (this.UserLoginData.isAdmin) {
          this.router.navigate(['/adminProfile'], { state: { user: this.UserLoginData } });
        } else {
          this.router.navigate(["/customerProfile"], { state: { user: this.UserLoginData } });
        }
      },
      err => {
        alert("Failed Login");
      }
    );
  }
}
