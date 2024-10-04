import { CommonModule, CurrencyPipe, DatePipe, DecimalPipe, JsonPipe, LowerCasePipe, NumberFormatStyle, PercentPipe, SlicePipe, TitleCasePipe, UpperCasePipe } from '@angular/common';
import { Component, Pipe } from '@angular/core';
import { EvennumbsPipe } from '../evennumbs.pipe';


@Component({
  selector: 'app-pipes',
  standalone: true,
  imports: [CommonModule,LowerCasePipe,UpperCasePipe,TitleCasePipe,SlicePipe,JsonPipe,DecimalPipe,PercentPipe,CurrencyPipe,DatePipe,EvennumbsPipe],
  templateUrl: './pipes.component.html',
  styleUrl: './pipes.component.css'
})
export class PipesComponent {
myText = "HElLo In ANgUlar";
myDate = new Date();
// myInfo = JSON.stringify({
//   'name':'aya',
//    'age' :22
// });
myInfo ={
  'name' : 'aya',
  'age' : 22
}
myNum = 123.233;
s = 0;
e = 3;

myNums = [1,2,3,4,5,6,7];
}
