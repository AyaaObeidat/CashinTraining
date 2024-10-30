import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../../../services/user.service';

@Injectable({
  providedIn: 'root',
})
export class AdminServService {
  private adminData: any;
  constructor(private _http: HttpClient,private userService : UserService) {}
  SetAdminData(data: any) {
    this.adminData = data;
  }
  GetAdminData() {
    return this.adminData;
  }
  ModifyAdminData(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    if (data.newFullName !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyFullName',
        data,
        options
      );
    } else {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyPassword',
        data,
        options
      );
    }
  }
}
