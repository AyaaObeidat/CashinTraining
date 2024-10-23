import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisteredCustomersService {

  constructor(private _http : HttpClient) { }
  GetAllCustomerRegistrationRequests():Observable<any>{
    return this._http.get<any>('https://localhost:44367/api/Admin/GetAllPendingCustomer');
  }

  AcceptCustomer(data:any):Observable<any>{
    debugger
    return this._http.post<any>('https://localhost:44367/api/Admin/AcceptNewCustomer',data);
  }
  RejectCustomer(data:any):Observable<any>{
    return this._http.post<any>('https://localhost:44367/api/Admin/RejectCustomer',data);
  }
  GetAllAcceptingCustomers():Observable<any>{
    return this._http.get<any>('https://localhost:44367/api/Admin/GetAllAcceptedCustomer');
  }
  GetAllBlockedCustomers():Observable<any>{
    return this._http.get<any>('https://localhost:44367/api/Admin/GetAllBlockedCustomer');
  }
  UnblockCustomer(data:any):Observable<any>{
    return this._http.post<any>('https://localhost:44367/api/Admin/UnBlockCustomer',data);
  }
}
