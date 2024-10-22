import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminServService {
  private adminData: any;
  constructor(private _http: HttpClient) {}
  SetAdminData(data: any) {
    this.adminData = data;
  }
  GetAdminData() {
    return this.adminData;
  }
  ModifyAdminData(data: any): Observable<any> {
    debugger;
    if (data.newFullName !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyFullName',
        data
      );
    } else {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyPassword',
        data
      );
    }
  }
}
