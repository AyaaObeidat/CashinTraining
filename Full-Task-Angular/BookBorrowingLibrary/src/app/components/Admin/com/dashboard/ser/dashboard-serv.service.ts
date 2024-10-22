import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DashboardServService {
  constructor(private _http: HttpClient) {}
  GetAllBooks(): Observable<any> {
    return this._http.get<any>('https://localhost:44367/api/Admin/GetAllBooks');
  }
  ModifyBookData(data: any): Observable<any> {
    if (data.newTitle !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyTitle',
        data
      );
    } else if (data.newAuthor !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyAuthor',
        data
      );
    } else if (data.newPublisher !== '') {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyPublisher',
        data
      );
    } else if (data.newNumberOfAvailableCopies !== 0) {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/BuyNewCopies',
        data
      );
    } else {
      return this._http.patch<any>(
        'https://localhost:44367/api/Admin/ModifyPublisherYear',
        data
      );
    }
  }
  AddNewBook(data: any): Observable<any> {
    debugger
    return this._http.post<any>(
      'https://localhost:44367/api/Admin/AddNewBook',
      data
    );
  }
}
