import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { RentalService } from '../rental.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { CarService } from 'src/app/car/car.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';
import { CustomerService } from 'src/app/customer/customer.service';
import { LocationService } from 'src/app/location/location.service';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import {NgTempusdominusBootstrapInput} from 'tempusdominus-bootstrap-4';
import * as moment from 'moment';

@Component({
  selector: 'app-rental-form',
  templateUrl: './rental-form.component.html',
  styleUrls: ['./rental-form.component.scss']
})
export class RentalFormComponent implements OnInit {

  // bsInlineValue = new Date();
  bsConfig: Partial<BsDatepickerConfig>;


  constructor(
    private route: ActivatedRoute,
    private carService: CarService,
    private rentalService: RentalService,
    private customerService: CustomerService,
    private locationService: LocationService,
    private router: Router,
    private alertify: AlertifyService,
    private bsConfigure: BsDatepickerConfig
  ) { }

  // bsConfigure.dateInputFormat = 'DD MMM YYYY';

  public rental: any = {};
  public customers: any = [];
  public cars: any = [];
  public locations: any = [];
  public pickUpLocation: any = [];
  public dropOffLocation: any = [];
  public selectedCustomerId: any = {};
  public selectedPickUpLocationId: any = {};
  public selectedDropOffLocationId: any = {};
  public selectedCarId: any = {};
  public errorMessage = '';


  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      const rentalId = params.id;
      this.getCars();
      this.getLocations();
      this.getCustomers();
      if (rentalId != null) {
        this.getRental(rentalId);
      }
    });
  }

  getCars() {
    this.carService.getAll().subscribe(response => {
      this.cars = response;
    }
    );
  }

  getCustomers() {
    this.customerService.getAll().subscribe(response => {
      this.customers = response;
    });
  }

  getLocations() {
    this.locationService.getAll().subscribe(response => {
      this.locations = response;
    });
  }

  onSubmit() {
    this.rental.carId = this.selectedCarId;
    this.rental.customerId = this.selectedCustomerId;
    this.rental.pickUpLocationId = this.selectedPickUpLocationId;
    this.rental.dropOffLocationId = this.selectedDropOffLocationId;

    // if (this.rental.startDate) { this.rental.startDate = moment(this.rental.startDate).format(); }
    // if (this.rental.endDate) { this.rental.endDate = moment(this.rental.endDate).format(); }


    this.rentalService.submit(this.rental).subscribe(
      (response: any) => {
        this.alertify.success('Success');
        this.router.navigate(['rentals']);
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
      });
  }

  getRental(rentalId) {
    this.rentalService.getOne(rentalId).subscribe(response => {
      this.rental = response;
      this.rental.id = rentalId;
      this.selectedCarId = this.rental.carId;
      this.selectedCustomerId = this.rental.customerId;
      this.selectedPickUpLocationId = this.rental.pickUpLocationId;
      this.selectedDropOffLocationId = this.rental.dropOffLocationId;
      this.rental.startDate = new Date(this.rental.startDate);
      this.rental.endDate = new Date(this.rental.endDate);
      // this.car.id = carId;
    });

  }

  cancelForm() {
    this.router.navigate(['rentals']);
  }

}

