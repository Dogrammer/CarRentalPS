import { Component, OnInit } from '@angular/core';
import { CityService } from '../city.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-city-list',
  templateUrl: './city-list.component.html',
  styleUrls: ['./city-list.component.scss']
})
export class CityListComponent implements OnInit {

  constructor(
    private cityService: CityService,
    private alertify: AlertifyService,
    private router: Router) { }

  cities: any;

  ngOnInit() {
    this.getAllCities();
  }

  getAllCities() {
    this.cityService.getAll().subscribe(response => {
      this.cities = response;
    });
  }

  onDelete(cityId) {
    this.alertify.confirm('Jeste li sigurni da želite obrisati ovaj Grad?', () => {
      this.cityService.deleteOne(cityId).subscribe(() => {
        this.alertify.success('Grad je uspješno obrisano');
        this.getAllCities();
      }, error => {
        this.alertify.error('Pogreška pri brisanju grada');
      });
    });
  }


  onAdd() {
    this.router.navigate(['cities/new']);
  }

   onEdit(cityId) {
    this.router.navigate(['cities', cityId]);
  }

  // softDelete(cityId) {
  //   if (confirm('Da li ste sigurni?')) {
  //       return this.cityService.patch( { op: 'replace', path: '/isDeleted', value: true }, cityId).subscribe(response => {
  //         this.alertify.success('jeeeej');
  //       });
  //   }

  // }
}
