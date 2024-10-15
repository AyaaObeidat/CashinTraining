import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { hostname } from 'os';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';

export const routes: Routes = [
    {path : "" , component : HomeComponent},
    {path : "register" , component : RegisterComponent},
    {path : "login" , component : LoginComponent}
];
