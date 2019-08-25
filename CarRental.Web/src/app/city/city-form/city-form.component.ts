import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CityService } from '../city.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';

@Component({
  selector: 'app-city-form',
  templateUrl: './city-form.component.html',
  styleUrls: ['./city-form.component.scss']
})
export class CityFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private cityService: CityService,
    private router: Router,
    private alertify: AlertifyService
  ) { }

  public city: any = {};
  public errorMessage = '';

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      const cityId = params.id;
      // this.getCities();
      if (cityId != null) {
        this.getCity(cityId);
      }
    });
  }


  onSubmit() {
    this.city.cityId = 1;
    this.cityService.submit(this.city).subscribe(
      (response: any) => {
        this.alertify.success('Success');
        this.router.navigate(['cities']);
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
      });
  }

  getCity(cityId) {
    this.cityService.getOne(cityId).subscribe(response => {
      this.city = response;
      this.city.id = cityId;
      // this.car.id = carId;
    });

  }

  cancelForm() {
    this.router.navigate(['cities']);
  }

}
