import { Directive, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appEvenMinutes]',
  standalone: true,
})
export class EvenMinutesDirective {
 @Input('appEvenMinutes') set SetElement(c : boolean)
 {
  if(c)
  {
    this.vcRef.createEmbeddedView(this.temRef);
  }
 }
  constructor(
    private temRef: TemplateRef<any>,
    private vcRef: ViewContainerRef
  ) {}

 
}
