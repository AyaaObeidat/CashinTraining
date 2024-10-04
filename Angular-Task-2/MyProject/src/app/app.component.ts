import { AfterViewInit, Component, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EvenMinutesDirective } from './even-minutes.directive';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, EvenMinutesDirective,DatePipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppComponent implements OnInit{
  myDate = new Date();
  isActive = false;
  minutes = this.myDate.getMinutes();
  constructor() {
   
  }
  ngOnInit(): void {
    if(this.minutes%2 == 0)
      this.isActive = true;
  }
}
