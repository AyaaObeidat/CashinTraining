import { UserService } from './../../../../../../services/user.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { __core_private_testing_placeholder__ } from '@angular/core/testing';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookServService {
  constructor(private _http: HttpClient, private userService: UserService) {}
  GetAllBooks(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllBooks',
      options
    );
  }
  ModifyBookData(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    if (data.newTitle !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyTitle',
        data,
        options
      );
    } else if (data.newAuthor !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyAuthor',
        data,
        options
      );
    } else if (data.newPublisher !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyPublisher',
        data,
        options
      );
    } else if (data.newNumberOfAvailableCopies !== 0) {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/BuyNewCopies',
        data,
        options
      );
    } else {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyPublisherYear',
        data,
        options
      );
    }
  }
  AddNewBook(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/AddNewBook',
      data,
      options
    );
  }
  GetAllDamagedBooks(): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.get<any>(
      'https://localhost:44367/api/Admin/GetAllDamagedBooks',
      options
    );
  }
  Repair(data: any): Observable<any> {
    const headers = this.userService.GetHeaderToken();
    const options = { headers };
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/RepairofDamagedCopy',
      data,
      options
    );
  }
}
