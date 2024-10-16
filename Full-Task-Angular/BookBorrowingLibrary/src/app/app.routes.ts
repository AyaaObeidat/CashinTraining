import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { hostname } from 'os';
import { LoginComponent } from './components/login/login.component';
import { AdminProfileComponent } from './components/admin-profile/admin-profile.component';
import { CustomerProfileComponent } from './components/Customer Components/customer-profile/customer-profile.component';
import { RegisterComponent } from './components/register/register.component';

export const routes: Routes = [
    {path : "" , component : HomeComponent},
    {path : "register" , component : RegisterComponent},
    {path : "login" , component : LoginComponent},
    {path : "adminProfile" , component : AdminProfileComponent},
    {path : "customerProfile" , component : CustomerProfileComponent}
];
