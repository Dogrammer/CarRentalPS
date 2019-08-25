import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarCategoryService } from '../carCategory.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';

@Component({
  selector: 'app-car-category-form',
  templateUrl: './car-category-form.component.html',
  styleUrls: ['./car-category-form.component.scss']
})
export class CarCategoryFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private categoryService: CarCategoryService,
    private router: Router,
    private alertify: AlertifyService
  ) { }

  public category: any = {};
  public errorMessage = '';

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      const categoryId = params.id;
      this.getCategory(categoryId);
      if (categoryId != null) {
        this.getCategory(categoryId);
      }
    });
  }
  getCategories() {
     this.categoryService.getAll().subscribe(response => {
       this.category = response;
     });
  }


  onSubmit() {
    this.category.categoryId = 1;
    this.categoryService.submit(this.category).subscribe(
      (response: any) => {
        this.alertify.success('Success');
        this.router.navigate(['carCategories']);
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
      });
  }

  getCategory(categoryId) {
    this.categoryService.getOne(categoryId).subscribe(response => {
      this.category = response;
      this.category.id = categoryId;
      // this.car.id = carId;
    });

  }

  cancelForm() {
    this.router.navigate(['carCategories']);
  }

}
