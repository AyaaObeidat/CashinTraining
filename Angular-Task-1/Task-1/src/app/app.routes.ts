import { Routes } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { GetAllComponent } from './components/get-all/get-all.component';

export const routes: Routes = [
  
  {
    path:'header',
    component:HeaderComponent
  },
  {
    path:'getall',
    component:GetAllComponent
  },
 
];
