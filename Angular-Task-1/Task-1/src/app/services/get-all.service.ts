import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GetAllService {

  private _http: HttpClient;

  constructor(http : HttpClient ) { 
    this._http = http;
  }

  getAll(): Observable<any> {
    return this._http.get<any>("https://localhost:44305/api/User/GetAll")
      
  }
}
