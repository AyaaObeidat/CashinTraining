import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { PipesComponent } from "./pipes/pipes.component";
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { EvennumbsPipe } from './evennumbs.pipe';
import { EvenMinutesDirective } from './even-minutes.directive';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [EvenMinutesDirective,CommonModule,RouterOutlet, PipesComponent , FormsModule,EvennumbsPipe],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']  // Corrected to styleUrls
})
export class AppComponent {

 myDate = new Date();
 minutes = this.myDate.getMinutes();
}
