import { UserService } from './../../../../../../services/user.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BorrRetReqService {
  constructor(private _http: HttpClient, private userService: UserService) {}
  GetAllCustomerBorrowingRequsets(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllBorrowBooksPendingRequests',
      options
    );
  }
  AcceptRequest(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/AcceptBorrowingBookRequest',
      data,
      options
    );
  }
  RejectRequest(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/RejectBorrowingBookRequest',
      data,
      options
    );
  }
  GetAllAcceptedCustomerBorrowingRequsets(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllBorrowBooksAcceptingRequests',
      options
    );
  }
  GetAllBookReturnedRequsets(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllReturnBooksTransactions',
      options
    );
  }
  SetNonCorruptBookStatus(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/ReturnBookStatus',
      data,
      options
    );
  }
  SetDamagedBookStatus(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/ReturnBookStatus',
      data,
      options
    );
  }
}
