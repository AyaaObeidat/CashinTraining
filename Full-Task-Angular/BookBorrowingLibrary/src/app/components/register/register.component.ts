import { UserService } from './../../services/user.service';
import { Component, Renderer2 } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [HeaderComponent, FormsModule, CommonModule,RouterOutlet,RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  user = {
    fullName: '',
    email: '',
    phoneNumber: 0,
    password: '',
  };
  constructor(private userService: UserService, private router : Router , private render : Renderer2) {}
  ngOnInit()
  {
    this.render.setStyle(document.body,'backgroundColor','#313b31');
  }
  OnDistroy(){
    this.render.removeStyle(document.body,'backgroundColor');
  }
  GetRegistraionData() {
    if (
      this.user.fullName != '' &&
      this.user.email != '' &&
      this.user.password != '' &&
      this.user.phoneNumber != 0
    ) {
      this.userService.Register(this.user).subscribe(
        res => {this.router.navigate(["/login"])},
        err => {alert("Error Creating User")}
      )
    }
  }
}
