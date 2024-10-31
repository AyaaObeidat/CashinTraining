import { Component, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { AdminHeaderComponent } from '../admin-header/admin-header.component';
import { CommonModule, DOCUMENT } from '@angular/common';
import { AdminServService } from '../../ser/admin-serv.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin-profile',
  standalone: true,
  imports: [AdminHeaderComponent,FormsModule,CommonModule],
  templateUrl: './admin-profile.component.html',
  styleUrl: './admin-profile.component.css',
})
export class AdminProfileComponent implements OnInit, OnDestroy {
  admin:any;
  newFullName = '';
  currentPassword = '';
  newPassword = '';
  confirmPassword = '';
  toEdit = false;
  constructor(
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document,
    private adminServ : AdminServService
  ) {
    this.admin = this.adminServ.GetAdminData();
  }
  ngOnInit(): void {
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
    return this.adminServ
      .ModifyAdminData({
        id: this.admin?.id,
        newFullName: this?.newFullName,
        currentPassword: this?.currentPassword,
        newPassword: this?.newPassword,
      })
      .subscribe(
        (res) => {
          if (this.newFullName !== '') {
            this.admin.fullName = this.newFullName;
          } else {
            this.admin.password == this.newPassword;
          }
          this.newFullName = '';
          this.currentPassword = '';
          this.newPassword = '';
          this.confirmPassword = '';
        },
       err => {}
      );
  }
}
