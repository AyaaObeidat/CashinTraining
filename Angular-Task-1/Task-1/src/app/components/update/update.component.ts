import { Component } from '@angular/core';
import { UpdateService } from '../../services/updateService/update.service';
import { ActivatedRoute } from '@angular/router';
import { ViewService } from '../../services/viewService/view.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './update.component.html',
  styleUrl: './update.component.css',
})
export class UpdateComponent {
  userId: any;
  user: any = null;
  _route: ActivatedRoute;
  _viewService: ViewService;
  _updateService: UpdateService;
  confirmPassword = '';
  data = {
    currentName: '',
    newName:'',
    currentPassword: '',
    newPassword: '',
  };
  
  constructor(
    route: ActivatedRoute,
    viewService: ViewService,
    updateService: UpdateService
  ) {
    this._route = route;
    this._viewService = viewService;
    this._updateService = updateService;
  }

  ngOnInit(): void {
    this._route.paramMap.subscribe((params) => {
      const idParam = params.get('id');
      if (idParam !== null) {
        this.userId = idParam;
        this.getUserDetails();
      } else {
        alert('No ID parameter found in the URL');
      }
    });
  }

  getUserDetails(): void {
    if (this.userId) {
      this._viewService.GetById(this.userId).subscribe(
        (res) => {
          this.user = res;
        },
        (err) => {
          alert('User not found');
        }
      );
    }
  }
  UpdateUserData() {
    debugger
    this.data.currentName = this.user.tripleName;
    if (this.user.password == this.data.currentPassword) {
      if (this.data.newPassword == this.confirmPassword) {
        this._updateService.UpdateUser(this.data).subscribe(
          (res) => alert('Successfuly Updated'),
          (err) => alert('Failed')
        );
      } else {
        alert('Password is not similar');
      }
    } else {
      alert('not found');
    }
  }
}
