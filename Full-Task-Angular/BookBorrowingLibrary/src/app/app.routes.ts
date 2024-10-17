import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { hostname } from 'os';
import { LoginComponent } from './components/login/login.component';
import { AdminProfileComponent } from './components/admin-profile/admin-profile.component';
import { RegisterComponent } from './components/register/register.component';
import { CustomerProfileComponent } from './components/Customer/com/customer-profile/customer-profile.component';
import { CustomerHomeComponent } from './components/Customer/com/customer-home/customer-home.component';
import { CartComponent } from './components/Customer/com/cart/cart.component';


export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'adminProfile', component: AdminProfileComponent },
  { path: 'customerHome', component: CustomerHomeComponent },
  { path: 'customerProfile', component: CustomerProfileComponent },
  { path: 'cart', component: CartComponent },
];
