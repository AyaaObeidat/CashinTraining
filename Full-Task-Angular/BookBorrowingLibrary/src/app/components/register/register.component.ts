import { UserService } from './../../services/user.service';
import { Component, Renderer2, Inject, OnInit, OnDestroy } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { HeaderComponent } from '../header/header.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [HeaderComponent, FormsModule, CommonModule, RouterOutlet, RouterLink],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'], // Corrected: styleUrls instead of styleUrl
})
export class RegisterComponent implements OnInit, OnDestroy {
  user = {
    fullName: '',
    email: '',
    phoneNumber: 0,
    password: '',
  };

  constructor(
    private userService: UserService,
    private router: Router,
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document 
  ) {}

  ngOnInit() {
    // Corrected: Use injected document
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
  }

  ngOnDestroy() { 
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }

  GetRegistrationData() {
    if (
      this.user.fullName !== '' &&
      this.user.email !== '' &&
      this.user.password !== '' &&
      this.user.phoneNumber !== 0
    ) {
      this.userService.Register(this.user).subscribe(
        res => { this.router.navigate(['/login']); },
        err => { alert('Error Creating User'); }
      );
    }
  }
}
