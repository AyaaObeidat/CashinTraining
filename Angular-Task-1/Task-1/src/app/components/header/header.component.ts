import { CreateComponent } from '../create/create.component';
import { Component } from '@angular/core';
import { GetAllComponent } from '../get-all/get-all.component';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [GetAllComponent, RouterOutlet, CreateComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {}
