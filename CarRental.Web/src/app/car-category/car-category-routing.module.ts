import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CarCategoryListComponent } from './car-category-list/car-category-list.component';
import { CarCategoryFormComponent } from './car-category-form/car-category-form.component';


const routes: Routes = [
  { path: 'carCategories', component: CarCategoryListComponent },
  { path: 'carCategories/new', component: CarCategoryFormComponent },
  { path: 'carCategories/:id', component: CarCategoryFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarCategoryRoutingModule { }
