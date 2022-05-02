import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ForgotPasswordComponent } from './auth/forgot-password/forgot-password.component';
import { ChangePasswordComponent } from './auth/change-password/change-password.component';
import { CartComponent } from './cart/cart.component';
import { CreateCategoryComponent } from './admin/create-category/create-category.component';
import { RouteGuardService } from './shared/auth/route-guard.service';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component:LoginComponent },
  { path: 'register', component:RegisterComponent},
  { path: 'forgot-password', component:ForgotPasswordComponent},
  { path: 'change-password', component:ChangePasswordComponent},
  { path: 'shopping-cart', component:CartComponent},
  { 
    path: 'admin/create-category', 
    component:CreateCategoryComponent,
    canActivate: [RouteGuardService],
    data: {
      expectedRole: 'admin'
    }
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
