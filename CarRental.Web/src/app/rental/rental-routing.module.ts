import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RentalListComponent } from './rental-list/rental-list.component';
import { RentalFormComponent } from './rental-form/rental-form.component';


const routes: Routes = [
  { path: 'rentals', component: RentalListComponent },
  { path: 'rentals/new', component: RentalFormComponent },
  { path: 'rentals/:id', component: RentalFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RentalRoutingModule { }
