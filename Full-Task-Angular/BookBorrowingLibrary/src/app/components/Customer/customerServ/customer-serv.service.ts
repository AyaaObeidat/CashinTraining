import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerServService {
  private customerData : any;
  constructor() { }
   SetCustomerData(data : any)
  {
    this.customerData = data;
  }

   GetCustomerData()
  {
    return this.customerData;
  }
}
