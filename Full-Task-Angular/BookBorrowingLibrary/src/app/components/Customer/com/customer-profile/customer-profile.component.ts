import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { CommonModule, DOCUMENT } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerHeaderComponent } from '../customer-header/customer-header.component';
import { CustomerServService } from '../../serv/customer-serv.service';
@Component({
  selector: 'app-customer-profile',
  standalone: true,
  imports: [CustomerHeaderComponent, CommonModule, FormsModule],
  templateUrl: './customer-profile.component.html',
  styleUrl: './customer-profile.component.css',
})
export class CustomerProfileComponent implements OnInit, OnDestroy {
  customer: any;
  newFullName = '';
  currentPassword = '';
  newPassword = '';
  confirmPassword = '';
  newPhoneNumber = 0;
  toEdit = false;
  constructor(
    @Inject(DOCUMENT) private document: Document,
    private render: Renderer2,
    private customerServ: CustomerServService
  ) {
    this.customer = this.customerServ.GetCustomerData();
  }
  ngOnInit() {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }

  ClickToEdit() {
    this.toEdit = true;
  }
  ClickToSave() {
    this.toEdit = false;
    return this.customerServ
      .ModifyCustomerData({
        id: this.customer.id,
        newFullName: this.newFullName,
        currentPassword: this.currentPassword,
        newPassword: this.newPassword,
        newPhoneNumber: this.newPhoneNumber,
      })
      .subscribe(
        (res) => {
          alert('Updated Successfuly');
          if (this.newFullName !== '') {
            this.customer.fullName = this.newFullName;
          } else if (this.newPhoneNumber !== 0) {
            this.customer.phoneNumber = this.newPhoneNumber;
          } else {
            this.customer.password == this.newPassword;
          }
          this.newFullName = '';
          this.currentPassword = '';
          this.newPassword = '';
          this.confirmPassword = '';
          this.newPhoneNumber = 0;
        },
        (err) => alert('Faild')
      );
  }
}
