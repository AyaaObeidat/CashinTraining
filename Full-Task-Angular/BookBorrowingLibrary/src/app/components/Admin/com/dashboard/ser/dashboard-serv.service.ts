import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardServService {

  constructor(private _http : HttpClient) { }
  GetAllBooks():Observable<any>
  {
    return this._http.get<any>("https://localhost:44367/api/Admin/GetAllBooks");
  }
}
