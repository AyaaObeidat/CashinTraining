import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GetAllService {

  private apiUrl = 'https://localhost:44305/api/User/GetAll';

  constructor(private http: HttpClient) { }

  getAll(): Observable<any> {
    return this.http.get<any>(this.apiUrl)
      .pipe(
        catchError(this.handleError) // Optional error handling
      );
  }

  private handleError(error: any): Observable<never> {
    // Customize error handling here
    console.error('An error occurred:', error);
    throw error;
  }
}
