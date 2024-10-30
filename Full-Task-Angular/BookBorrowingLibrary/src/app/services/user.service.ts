import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}
  GetHeaderToken(): HttpHeaders {
    const _header = new HttpHeaders({
      Authorization: `Bearer ${'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBeWFhIE1vaCBPYmVpZGF0IiwianRpIjoiZDE4OWVjZjktOTFjZi00YWZiLWE3ZWEtNjI3NTg0N2EyMjU2IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiI4ZmJkNzE4MS1lNzQ5LTQ0N2ItMWViZS0wOGRjZTdhNzE5ZWUiLCJleHAiOjE3MzA4OTU0NjUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzY3IiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNjcifQ.rUXYrLA8YziUaxbvrcAvppdn0jQ5Xo3REwy1D2nQIr0'}`,
      'Content-Type': 'application/json',
    });

    return _header;
  }
  Register(data: any): Observable<any> {
    return this.http.post<any>(
      'https://localhost:44367/api/Customer/Register',
      data
    );
  }

  Login(data: any): Observable<any> {
    return this.http.post<any>(
      'https://localhost:44367/api/Customer/Login',
      data
    );
  }
}
