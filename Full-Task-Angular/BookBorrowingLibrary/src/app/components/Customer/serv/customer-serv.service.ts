import { UserService } from './../../../services/user.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomerServService {
  private customerData: any;

  constructor(private _http: HttpClient, private userService: UserService) {}

  SetCustomerData(data: any) {
    this.customerData = data;
  }

  GetCustomerData() {
    return this.customerData;
  }

  ModifyCustomerData(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };

    if (data.newFullName !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Customer/ModifyFullName',
        data,
        options
      );
    } else if (data.newPhoneNumber !== 0) {
      return this._http.patch<any>(
        'https://localhost:44367/api/Customer/ModifyPhoneNumber',
        data,
        options
      );
    } else {
      return this._http.patch<any>(
        'https://localhost:44367/api/Customer/ModifyPassword',
        data,
        options
      );
    }
  }

  ReturnBorrowedBook(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    return this._http.post<any>(
      'https://localhost:44367/api/Customer/Return_Book',
      data,
      { headers }
    );
  }

  GetAllBooks(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllBooks',
      { headers }
    );
  }

  BorrowBook(data: any): Observable<any> {
    debugger
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Customer/Borrow_Book',
      data,
      options
    );
  }
}
