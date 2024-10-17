import { Component,Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { CustomerHeaderComponent } from '../customer-header/customer-header.component';
import { CommonModule, DOCUMENT } from '@angular/common';
import { CustomerServService } from '../customerServ/customer-serv.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-customer-profile',
  standalone: true,
  imports: [CustomerHeaderComponent,CommonModule,FormsModule],
  templateUrl: './customer-profile.component.html',
  styleUrl: './customer-profile.component.css',
})
export class CustomerProfileComponent implements OnInit, OnDestroy {
  customer : any;
  newFullName?: string;
  currentPassword?:string;
  newPassword?:string;
  confirmPassword?:string;
  newPhoneNumber?:number;
  toEdit = false;
  constructor(
    @Inject(DOCUMENT) private document: Document,
    private render: Renderer2,
    private customerServ : CustomerServService,
  ) {
    this.customer = this.customerServ.GetCustomerData();
  }
  ngOnInit(){
    this.render.setStyle(this.document.body,'backgroundColor','#313b31');
  }
  ngOnDestroy(): void {
     this.render.removeStyle(this.document.body,'backgroundColor');
  }

  ClickToEdit()
  {
    this.toEdit = true;
  }
  ClickToSave()
  {
    this.toEdit = false;
    
  }
}
