import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GetAllService } from './services/getAllService/get-all.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from "./components/header/header.component";
import { CreateService } from './services/createService/create.service';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { ViewService } from './services/viewService/view.service';
import { UpdateService } from './services/updateService/update.service';
import { LoginService } from './services/loginService/login.service';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, HeaderComponent , FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers:[GetAllService,CreateService,ViewService,UpdateService,LoginService],
  
})
export class AppComponent {
  title = 'Task-1';
}
