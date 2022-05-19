import { NgModule } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './header/navbar/navbar.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './auth/login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './auth/register/register.component';
import { ForgotPasswordComponent } from './auth/forgot-password/forgot-password.component';
import { ChangePasswordComponent } from './auth/change-password/change-password.component';

import { HttpClientModule } from '@angular/common/http';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtHelperService, JwtModule, JwtModuleOptions } from '@auth0/angular-jwt';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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

const JWT_Module_Options: JwtModuleOptions = {
    config: {
        tokenGetter: tokenGetter
    }
};

export function tokenGetter() {
  return localStorage.getItem("jwt");
}


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    ChangePasswordComponent,
    TestComponent,
    ProductListComponent,
    AdminLayoutComponent,
    AdminNavLayoutComponent,
    CreateCategoryComponent,
    ViewCategoriesComponent,
    AddProductComponent,
    ViewProductsComponent,
    UserShopLayoutComponent,
    ProoductDetailsComponent,
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot(JWT_Module_Options),
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    JwtHelperService,
    Title
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
