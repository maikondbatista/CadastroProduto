import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription, take } from 'rxjs';
import { Category } from 'src/app/shared/models/category.model';
import { CategoryService } from 'src/app/shared/services/category.service';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.scss'],
})
export class CategoryFormComponent implements OnInit, OnDestroy {
  @Input() category!: Category;
  @Output() onCreateNew: EventEmitter<any> = new EventEmitter<any>();
  form!: FormGroup;
  subscriptions: Subscription[] = [];
  constructor(
    private fb: FormBuilder,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.createForm();
    this.subscriptions.push(
      this.categoryService.categorySubject.subscribe((category) => {
        this.form.patchValue(category);
      })
    );
  }

  createForm() {
    this.form = this.fb.group({
      id: null,
      name: null,
      created: null,
      updated: null,
    });
  }

  save() {
    if (this.newCategory) {
      this.categoryService
        .Save(this.form.value)
        .pipe(take(1))
        .subscribe((s) => {
          this.cancel();
          this.onCreateNew.emit();
        });
    } else {
      this.categoryService
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
  }

  get newCategory() {
    return !(this.form.controls['id'].value > 0);
  }
  get categoryId() {
    return this.form.controls['id'];
  }
}
