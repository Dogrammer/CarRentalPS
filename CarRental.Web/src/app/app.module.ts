import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LocationModule } from './location/location.module';
import { RentalModule } from './rental/rental.module';
import { CustomerModule } from './customer/customer.module';
import { AppRoutingModule } from './app-routing.module';
import { CarModule } from './car/car.module';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { FooterComponent } from './template/footer/footer.component';
import { CityModule } from './city/city.module';
import { CarCategoryModule } from './car-category/car-category.module';

import { AlertifyService } from './alertifyService/alertify.service';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap';
import { NavComponent } from './template/nav/nav.component';
import { HomeModule } from './home/home.module';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RentalModule,
    CarModule,
    CustomerModule,
    LocationModule,
    CityModule,
    CarCategoryModule,
    HomeModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
