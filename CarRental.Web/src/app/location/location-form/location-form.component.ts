import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LocationService } from '../location.service';
import { CityService } from 'src/app/city/city.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';

@Component({
  selector: 'app-location-form',
  templateUrl: './location-form.component.html',
  styleUrls: ['./location-form.component.scss']
})
export class LocationFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private locationService: LocationService,
    private router: Router,
    private cityService: CityService,
    private alertify: AlertifyService
  ) { }
  public location: any = {};
  public cities: any = [];
  public selectedCityId: any = {};
  public errorMessage = '';

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      const locationId = params.id;
      this.getCities();
      if (locationId != null) {
        this.getLocation(locationId);
      }
    });
  }

  getCities() {
    this.cityService.getAll().subscribe(response => {
      this.cities = response;
    }
    );
  }

  onSubmit() {
    this.location.cityId = this.selectedCityId;
    this.locationService.submit(this.location).subscribe(
      (response: any) => {
        this.alertify.success('Success');
        this.router.navigate(['locations']);
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
      });
  }

  getLocation(locationId) {
    this.locationService.getOne(locationId).subscribe(response => {
      this.location = response;
      this.location.id = locationId;
      this.selectedCityId = this.location.cityId;
      // this.car.id = carId;
    });

  }

  cancelForm() {
    this.router.navigate(['locations']);
  }

}
