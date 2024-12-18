import { Routes } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { GetAllComponent } from './components/get-all/get-all.component';
import { CreateComponent } from './components/create/create.component';
import { ViewComponent } from './components/view/view.component';
import { UpdateComponent } from './components/update/update.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';

export const routes: Routes = [
  { path: 'header', component: HeaderComponent },
  { path: 'create', component: CreateComponent },
  { path: 'getall', component: GetAllComponent },
  { path: 'view/:id', component: ViewComponent },
  { path: 'update/:id', component: UpdateComponent },
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent },
];
