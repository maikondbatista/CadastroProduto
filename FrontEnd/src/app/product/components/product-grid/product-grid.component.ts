import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { take } from 'rxjs';
import { Product } from 'src/app/shared/models/product.model';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.scss']
})
export class ProductGridComponent implements OnInit {
  page = 1;
  pageSize = 4;
  gridData!: Product[];
  dataSource!: Product[];
  @Output() onClickUpdate: EventEmitter<Product> = new EventEmitter<Product>();
  @Output() onClickDelete: EventEmitter<Product> = new EventEmitter<Product>();
  @Output() onClickProducts: EventEmitter<Product> = new EventEmitter<Product>();
  
  constructor(private productService: ProductService) {
    this.refreshGrid();
  }
  ngOnInit(): void {
  }

  refreshGrid() {
    this.productService.getAll().pipe(take(1)).subscribe(products => {
      this.dataSource = products;
    this.gridData = this.dataSource.slice(
      (this.page - 1) * this.pageSize,
      (this.page - 1) * this.pageSize + this.pageSize
    );
  })
  }

  products(product: Product) {
    this.onClickProducts.emit(product);
  }
  delete(product: Product) {
    this.productService.Delete(product).pipe(take(1)).subscribe(s => {
      this.refreshGrid();
    });
  }
  
  update(product: Product) {
    this.onClickUpdate.emit(product);
  }
}
