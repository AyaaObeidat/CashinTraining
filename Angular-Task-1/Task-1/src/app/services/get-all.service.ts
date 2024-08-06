import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetAllService {

  private readonly _http : HttpClient
  constructor(http : HttpClient) { 
    this._http = http;
  }

  GetAll():Observable<any>
  {
    return this._http.get<any>('https://localhost:44305/api/User/GetAll');
  }
}
