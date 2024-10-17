import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomerServService {
  private customerData: any;
  constructor(private _http: HttpClient) {}
  SetCustomerData(data: any) {
    this.customerData = data;
  }

  GetCustomerData() {
    return this.customerData;
  }

  ModifyCustomerData(data: any): Observable<any> {
    debugger;
    if (data.newFullName !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Customer/ModifyFullName',
        data
      );
    } else if (data.newPhoneNumber !== 0) {
      return this._http.patch<any>(
        'https://localhost:44367/api/Customer/ModifyPhoneNumber',
        data
      );
    } else {
      return this._http.patch<any>(
        'https://localhost:44367/api/Customer/ModifyPassword',
        data
      );
    }
  }
}
