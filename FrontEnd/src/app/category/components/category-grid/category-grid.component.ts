import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { take } from 'rxjs';
import { Category } from 'src/app/shared/models/category.model';
import { CategoryService } from 'src/app/shared/services/category.service';

@Component({
  selector: 'app-category-grid',
  templateUrl: './category-grid.component.html',
  styleUrls: ['./category-grid.component.scss'],
})
export class CategoryGridComponent {

  page = 1;
  pageSize = 4;
  dataSource!: Category[];
  gridData!: Category[];
  @Output() onClickUpdate: EventEmitter<Category> = new EventEmitter<Category>();
  constructor(private categoryService: CategoryService) {
    this.refreshGrid();

  }

  refreshGrid() {
    this.categoryService.getAll().pipe(take(1)).subscribe(categories=> {
      this.dataSource = categories;
    this.gridData = this.dataSource.slice(
      (this.page - 1) * this.pageSize,
      (this.page - 1) * this.pageSize + this.pageSize
    );
  })
  }

  delete(category: Category) {
    this.categoryService.Delete(category).pipe(take(1)).subscribe(s => {
      this.refreshGrid();
    });
  }
  update(category: Category) {
    this.onClickUpdate.emit(category);
  }
}
