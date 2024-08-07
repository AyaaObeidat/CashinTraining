import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GetAllService } from './services/getAllService/get-all.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from "./components/header/header.component";
import { CreateService } from './services/createService/create.service';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, HeaderComponent , FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers:[GetAllService,CreateService],
  
})
export class AppComponent {
  title = 'Task-1';
}
