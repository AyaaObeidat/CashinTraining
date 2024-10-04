import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ViewService {
  constructor(private http: HttpClient) {}

  GetById(id: any): Observable<any> {
    return this.http.post<any>('https://localhost:44305/api/User/GetById', {
      id,
    });
  }
}