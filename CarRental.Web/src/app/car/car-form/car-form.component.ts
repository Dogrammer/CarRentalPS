import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from '../car.service';
import { CarCategoryService } from 'src/app/car-category/carCategory.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';

@Component({
  selector: 'app-car-form',
  templateUrl: './car-form.component.html',
  styleUrls: ['./car-form.component.scss']
})
export class CarFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private carService: CarService,
    private categoryService: CarCategoryService,
    private router: Router,
    private alertify: AlertifyService
  ) { }

  public car: any = {};
  public categories: any = [];
  public selectedCategoryId: any = {};
  public errorMessage = '';

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      const carId = params.id;
      this.getCategories();
      if (carId != null) {
        this.getCar(carId);
      }
    });
  }

  getCategories() {
    this.categoryService.getAll().subscribe(response => {
      this.categories = response;
    }
    );
  }

  onSubmit() {
    this.car.carCategoryId = this.selectedCategoryId;
    this.carService.submit(this.car).subscribe(
      (response: any) => {
        this.alertify.success('Success');
        this.router.navigate(['cars']);
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
      });
  }

  getCar(carId) {
    this.carService.getOne(carId).subscribe(response => {
      this.car = response;
      this.car.id = carId;
      this.selectedCategoryId = this.car.carCategoryId;
      // this.car.id = carId;
    });

  }

  cancelForm() {
    this.router.navigate(['cars']);
  }

}
