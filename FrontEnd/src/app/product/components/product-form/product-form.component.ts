import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription, take } from 'rxjs';
import { Product } from 'src/app/shared/models/product.model';
import { Select } from 'src/app/shared/models/select.model';
import { CategoryService } from 'src/app/shared/services/category.service';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements AfterViewInit {
  @Input() product!: Product;
  @Output() onCreateNew: EventEmitter<any> = new EventEmitter<any>();
  form!: FormGroup;
  subscriptions: Subscription[] = [];
  categoriesSelect!: Select[]
  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    public categoryService: CategoryService
  ) {
    this.createForm();

  }

  ngAfterViewInit(): void {
    this.subscriptions.push(
      this.productService.productSubject.subscribe((product) => {
        this.form.patchValue(product);
      })
    );
    this.categoryService.getAll().pipe(take(1)).subscribe(categories => {
      this.categoriesSelect = categories.map(s => 
        {
          return { Text: s.name, Value: s.id } as Select;
        })
        if(this.newProduct)
          this.form.controls['categoryId'].patchValue(this.categoriesSelect[0].Value);
    });   
  }

  createForm() {
    this.form = this.fb.group({
      id: null,
      name: null,
      price: null,
      categoryId: null,
      created: null,
      updated: null,
    });
  }

  save() {
    if (this.newProduct) {
      this.productService
        .Save(this.form.value)
        .pipe(take(1))
        .subscribe((s) => {
          this.cancel();
          this.onCreateNew.emit();
        });
    } else {
      this.productService
        .Update(this.form.value)
        .pipe(take(1))
        .subscribe((s) => {
          this.cancel();
          this.onCreateNew.emit();
        });
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((sub) => sub.unsubscribe());
  }

  cancel() {
    this.form.reset();
    this.form.controls['categoryId'].patchValue(this.categoriesSelect[0]?.Value);
  }

  get newProduct() {
    return !(this.form.controls['id'].value > 0);
  }
  get productId() {
    return this.form.controls['id'];
  }
}
