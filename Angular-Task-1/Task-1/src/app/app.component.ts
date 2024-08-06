import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GetAllService } from './services/get-all.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from "./components/header/header.component";
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers:[GetAllService]
})
export class AppComponent {
  title = 'Task-1';
}
