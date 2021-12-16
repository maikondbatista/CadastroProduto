import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductRoutingModule } from './product-routing.module';
import { SharedModule } from '../shared/shared-module/shared-module.module';
import { IndexComponent } from './index/index.component';
import { ProductFormComponent } from './components/product-form/product-form.component';
import { ProductGridComponent } from './components/product-grid/product-grid.component';


@NgModule({
  declarations: [
    IndexComponent,
    ProductFormComponent,
    ProductGridComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    SharedModule.forRoot(),
  ]
})
export class ProductModule { }
