import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { ViewProductsComponent } from './view-products/view-products.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Product',
    },
    children: [
      {
        path: '',
        redirectTo: 'view',
      },
      {
        path: 'add',
        component: AddProductComponent,
        data: {
          title: 'Add Product',
        },
      },
      {
        path: 'view',
        component: ViewProductsComponent,
        data: {
          title: 'View Products',
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductRoutingModule {}

