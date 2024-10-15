import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient) { }
  Register(data : any) : Observable<any>
  {
    return this.http.post<any>("https://localhost:44367/api/Customer/Register",data);
  }
}
