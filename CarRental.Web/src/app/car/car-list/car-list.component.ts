import { Component, OnInit } from '@angular/core';
import { RentalService } from 'src/app/rental/rental.service';
import { CarService } from '../car.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.scss']
})
export class CarListComponent implements OnInit {

  constructor(
    private carService: CarService,
    private alertify: AlertifyService,
    private router: Router) { }

  cars: any;

  ngOnInit() {
    this.getAllCars();
  }

  getAllCars() {
    this.carService.getAll().subscribe(response => {
      this.cars = response;
    });
  }

  onDelete(carId) {
    this.alertify.confirm('Jeste li sigurni da želite obrisati ovo vozilo?', () => {
      this.carService.deleteOne(carId).subscribe(() => {
        this.alertify.success('Vozilo je uspješno obrisano');
        this.getAllCars();
      }, error => {
        this.alertify.error('Pogreška pri brisanju vozila');
      });
    });
  }

  onAdd() {
    this.router.navigate(['cars/new']);
  }

  onEdit(carId) {
    this.router.navigate(['cars', carId]);
  }

}
