import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { CustomerProfileComponent } from './components/Customer/com/customer-profile/customer-profile.component';
import { CustomerHomeComponent } from './components/Customer/com/customer-home/customer-home.component';
import { CartComponent } from './components/Customer/com/cart/cart.component';
import { AdminHomeComponent } from './components/Admin/com/admin-home/admin-home.component';
import { AdminProfileComponent } from './components/Admin/com/admin-profile/admin-profile.component';
import { ViewBookComponent } from './components/Admin/com/dashboard/com/Books-com/view-book/view-book.component';
import { EditBookComponent } from './components/Admin/com/dashboard/com/Books-com/edit-book/edit-book.component';
import { NewBookComponent } from './components/Admin/com/dashboard/com/Books-com/new-book/new-book.component';


export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'adminHome', component : AdminHomeComponent },
  { path: 'adminProfile', component : AdminProfileComponent },
  { path: 'customerHome', component: CustomerHomeComponent },
  { path: 'customerProfile', component: CustomerProfileComponent },
  { path: 'cart', component: CartComponent },
  { path: 'viewBook', component: ViewBookComponent },
  { path: 'editBook', component: EditBookComponent },
  { path: 'newBook', component: NewBookComponent },
];
