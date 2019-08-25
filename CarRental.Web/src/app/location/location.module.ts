import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LocationRoutingModule } from './location-routing.module';
import { LocationListComponent } from './location-list/location-list.component';
import { LocationFormComponent } from './location-form/location-form.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [LocationListComponent, LocationFormComponent],
  imports: [
    CommonModule,
    LocationRoutingModule,
    FormsModule
  ]
})
export class LocationModule { }
