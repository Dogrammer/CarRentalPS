import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CarCategoryRoutingModule } from './car-category-routing.module';
import { CarCategoryListComponent } from './car-category-list/car-category-list.component';
import { CarCategoryFormComponent } from './car-category-form/car-category-form.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [CarCategoryListComponent, CarCategoryFormComponent],
  imports: [
    CommonModule,
    CarCategoryRoutingModule,
    FormsModule
  ]
})
export class CarCategoryModule { }
