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
import { AdminNavLayoutComponent } from './_layout/admin-nav-layout/admin-nav-layout.component';
import { CreateCategoryComponent } from './admin/create-category/create-category.component';
import { ViewCategoriesComponent } from './admin/view-categories/view-categories.component';
import { AddProductComponent } from './admin/add-product/add-product.component';
import { ViewProductsComponent } from './admin/view-products/view-products.component';
import { UserShopLayoutComponent } from './_layout/user-shop-layout/user-shop-layout.component';
import { ProoductDetailsComponent } from './user/shop/prooduct-details/prooduct-details.component';
import { ContactComponent } from './user/contact/contact.component';
import { ShoppingCartComponent } from './user/shop/shopping-cart/shopping-cart.component';
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
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'change-password', component: ChangePasswordComponent },
  { path: 'temp', component: UserShopLayoutComponent },

  {
    path: 'admin',
    redirectTo: 'admin/dashboard',
    pathMatch: 'full',
  },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      {
        path: 'dashboard',
        component: AdminNavLayoutComponent,
        canActivate: [RouteGuardService],
        data: {
          expectedRole: "admin"
        }
      },
      {
        path: 'create-category',
        component: CreateCategoryComponent,
        data: {
          expectedRole: "admin"
        }
      },
      {
        path: 'view-categories',
        component: ViewCategoriesComponent,
        data: {
          expectedRole: "admin"
        }
      },
      {
        path: 'add-product',
        component: AddProductComponent,
        data: {
          expectedRole: "admin"
        }
      },
      {
        path: 'view-products',
        component: ViewProductsComponent,
        data: {
          expectedRole: "admin"
        }
      },
    ]
  },

  {
    path: 'user',
    redirectTo: 'user/shop',
    pathMatch: 'full'
  },
  {
    path:'user',
    component:UserShopLayoutComponent,
    children: [
      {
        path:'contact',
        component: ContactComponent,
        data: {
          active: 'contact'
        }
      },
      {
        path:'shop',
        component: ProductListComponent
      },
      {
        path:'shop/product-details',
        component: ProoductDetailsComponent
      },
      {
        path:'shop/shopping-cart',
        component: ShoppingCartComponent
      }
    ]
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Register Page'
    }
  },
  // {path: '**', redirectTo: 'dashboard'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {

    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
