import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tick } from '@angular/core/testing';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UpdateService {
  _http: HttpClient;
  constructor(http: HttpClient) {
    this._http = http;
  }

  UpdateUser(data: any): Observable<any> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBeWFhIE1vaGFtbWFkIE9iZWlkYXQiLCJqdGkiOiIwODNhNTVjZC03YmZiLTRhOWItYTI1YS1mMzlkMWNjNTg0NzgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjUwODBiNTdkLWNmNGMtNGQ1Zi1iZjk0LTA4ZGNhNDAyNDdkNyIsImV4cCI6MTcyMzczODY2MywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDUiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0NDMwNSJ9.tOuUw3HPbzBhgGbXqSVvHWyG-G3-gkviwUEfWa7eta0'}`,
      'Content-Type': 'application/json',
    });

    return this._http.patch<any>(
      'https://localhost:44305/api/User/ModifyPassword',
      data,
      { headers }
    );
  }
}
