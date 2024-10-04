import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appEvenMinutes]',
  standalone: true
})
export class EvenMinutesDirective {

  @Input('appEvenMinutes')
  set CheckMinutes(m : number)
  {
     if(m== null || m==undefined )
       {
        this.vcRef.clear();
       }
       else{
        if(m%2==0)
          this.vcRef.createEmbeddedView(this.temRef);
        else
          this.vcRef.clear();
       }
   }
 constructor(private temRef : TemplateRef<any> , private vcRef : ViewContainerRef) { }


}
