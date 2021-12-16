import { Component, OnInit, ViewChild } from '@angular/core';
import { Category } from 'src/app/shared/models/category.model';
import { CategoryService } from 'src/app/shared/services/category.service';
import { CategoryGridComponent } from '../components/category-grid/category-grid.component';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
@ViewChild("grid") gridComponent!: CategoryGridComponent;

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
  }

  update(category: Category){
    this.categoryService.setCategory(category);
  }

  delete(category: Category){
    console.log(category);
  }
  cancel()
  {
    this.categoryService.setCategory({} as Category);
  }

   refreshGrid(){
    this.gridComponent.refreshGrid();
  }
}
