import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoryRoutingModule } from './category-routing.module';
import { IndexComponent } from './index/index.component';
import { CategoryFormComponent } from './components/category-form/category-form.component';
import { SharedModule } from '../shared/shared-module/shared-module.module';
import { CategoryGridComponent } from './components/category-grid/category-grid.component';


@NgModule({
  declarations: [
    CategoryFormComponent,
    IndexComponent,
    CategoryGridComponent
  ],
  imports: [
    CommonModule,
    CategoryRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class CategoryModule { }
