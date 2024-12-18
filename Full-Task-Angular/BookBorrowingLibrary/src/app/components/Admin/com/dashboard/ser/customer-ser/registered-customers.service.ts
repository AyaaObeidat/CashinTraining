import { UserService } from './../../../../../../services/user.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RegisteredCustomersService {
  constructor(private _http: HttpClient, private userService: UserService) {}
  GetAllCustomerRegistrationRequests(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllPendingCustomer',
      options
    );
  }

  AcceptCustomer(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/AcceptNewCustomer',
      data,
      options
    );
  }
  RejectCustomer(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/RejectCustomer',
      data,
      options
    );
  }
  GetAllAcceptingCustomers(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllAcceptedCustomer',
      options
    );
  }
  GetAllBlockedCustomers(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllBlockedCustomer',
      options
    );
  }
  UnblockCustomer(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/UnBlockCustomer',
      data,
      options
    );
  }
}
