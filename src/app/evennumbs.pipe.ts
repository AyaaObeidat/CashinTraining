import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'evennumbs',
  standalone: true
})
export class EvennumbsPipe implements PipeTransform {

  transform(arr:Array<number>) {
    return (arr.filter(n => n%2===0));
  }

}
