import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timeout } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CreateService {
  private _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  Create(data: any): Observable<any> {
    return this._http.post<any>(
      'https://localhost:44305/api/User/Register',
      data
    );
  }
}
