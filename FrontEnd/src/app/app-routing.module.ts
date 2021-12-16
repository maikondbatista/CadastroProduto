import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'home', loadChildren:() => import('./home/home.module').then(m => m.HomeModule)},
  {path: 'produto', loadChildren:() => import('./product/product.module').then(m => m.ProductModule)},
  {path: 'categoria', loadChildren:() => import('./category/category.module').then(m => m.CategoryModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
