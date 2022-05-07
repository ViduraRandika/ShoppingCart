import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateCategory } from 'src/app/shared/admin/CreateCategory.model';
import { CreateCategoryComponent } from './create-category/create-category.component';
import { ViewCategoriesComponent } from './view-categories/view-categories.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Category',
    },
    children: [
      {
        path: '',
        redirectTo: 'view',
      },
      {
        path: 'add',
        component: CreateCategoryComponent,
        data: {
          title: 'Create Category',
        },
      },
      {
        path: 'view',
        component: ViewCategoriesComponent,
        data: {
          title: 'View Categories',
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CategoryRoutingModule {}

