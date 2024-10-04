import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EvenMinutesDirective } from './even-minutes.directive';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, EvenMinutesDirective],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  myDate = new Date();
  minutes = this.myDate.getMinutes();
}
