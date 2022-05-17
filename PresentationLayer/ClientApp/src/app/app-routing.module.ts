import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ForgotPasswordComponent } from './auth/forgot-password/forgot-password.component';
import { ChangePasswordComponent } from './auth/change-password/change-password.component';
import { RouteGuardService } from './shared/auth/route-guard.service';
import { TestComponent } from './test/test.component';
import { ProductListComponent } from './user/shop/product-list/product-list.component';
import { AdminLayoutComponent } from './_layout/admin-layout/admin-layout.component';
const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'test', component: TestComponent },
  { 
    path: 'home', component: HomeComponent,
    canActivate: [RouteGuardService],
    data: {
      expectedRole: "any"
    }
  },
  { path: 'login', component:LoginComponent },
  { path: 'register', component:RegisterComponent},
  { path: 'forgot-password', component:ForgotPasswordComponent},
  { path: 'change-password', component:ChangePasswordComponent},
  { path: 'shop/product-list', component:ProductListComponent},
  { path: 'temp', component:AdminLayoutComponent},
  // { 
  //   path: 'admin/create-category', 
  //   component:CreateCategoryComponent,
  //   canActivate: [RouteGuardService],
  //   data: {
  //     expectedRole: 'admin'
  //   }
  // },
  {
    path: 'admin',
    redirectTo: 'admin/dashboard',
    pathMatch: 'full'
  },
  // {
  //   path: 'admin',
  //   component: DefaultLayoutComponent,
  //   data: {
  //     title: 'Admin Dashboard'
  //   },
  //   children: [
  //     {
  //       path:'dashboard',
  //       loadChildren: () =>
  //         import('./admin/views/dashboard/dashboard.module').then((m) => m.DashboardModule)
  //     },
  //   ]
  // },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Register Page'
    }
  },
  {path: '**', redirectTo: 'dashboard'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
