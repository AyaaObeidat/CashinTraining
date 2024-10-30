import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HeaderComponent, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit, OnDestroy {
  user = {
    email: '',
    password: '',
  };

  UserLoginData: any;

  constructor(
    private userService: UserService,
    private router: Router,
    @Inject(DOCUMENT) private document: Document,
    private render: Renderer2
  ) {}
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
  }

  GetLoginData() {
    return this.userService.Login(this.user).subscribe(
      (res) => {
        this.UserLoginData = res.selectedUser;
        if (this.UserLoginData.isAdmin) {
          this.router.navigate(['/adminHome'], {
            state: { user: this.UserLoginData },
          });
        } else {
          this.router.navigate(['/customerHome'], {
            state: { user: this.UserLoginData },
          });
        }
      },
      (err) => {
        alert('Failed Login');
      }
    );
  }
}
