import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private _http : HttpClient) { }

  getUserData(data:any):Observable<any>
  {
   return this._http.post<any>('https://localhost:44305/api/User/Login',data);
  }
}
