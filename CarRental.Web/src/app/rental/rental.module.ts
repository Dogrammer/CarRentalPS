import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RentalRoutingModule } from './rental-routing.module';
import { RentalListComponent } from './rental-list/rental-list.component';
import { RentalFormComponent } from './rental-form/rental-form.component';
import { FormsModule } from '@angular/forms';
import { NgTempusdominusBootstrapModule } from 'ngx-tempusdominus-bootstrap';
import { DatepickerModule, BsDatepickerModule, BsDropdownModule } from 'ngx-bootstrap';


@NgModule({
  declarations: [RentalListComponent, RentalFormComponent],
  imports: [
    CommonModule,
    RentalRoutingModule,
    FormsModule,
    DatepickerModule,
    NgTempusdominusBootstrapModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
  ]
})
export class RentalModule { }
