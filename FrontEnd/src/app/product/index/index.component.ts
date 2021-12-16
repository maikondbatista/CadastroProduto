import { Component, OnInit, ViewChild } from '@angular/core';
import { Product } from 'src/app/shared/models/product.model';
import { ProductService } from 'src/app/shared/services/product.service';
import { ProductGridComponent } from '../components/product-grid/product-grid.component';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
@ViewChild("grid") gridComponent!: ProductGridComponent;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  update(product: Product){
    this.productService.setProduct(product);
  }

  delete(product: Product){
    console.log(product);
  }
  cancel()
  {
    this.productService.setProduct({} as Product);
  }

  refreshGrid(){
    this.gridComponent.refreshGrid();
  }
}
