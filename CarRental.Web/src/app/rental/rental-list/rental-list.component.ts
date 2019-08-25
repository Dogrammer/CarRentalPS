import { Component, OnInit } from '@angular/core';
import { RentalService } from '../rental.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rental-list',
  templateUrl: './rental-list.component.html',
  styleUrls: ['./rental-list.component.scss']
})
export class RentalListComponent implements OnInit {

  constructor(
    private rentalService: RentalService,
    private alertify: AlertifyService,
    private router: Router) { }

  rentals: any;

  ngOnInit() {
    this.getAllRentals();
  }

  getAllRentals() {
    this.rentalService.getAll().subscribe(response => {
      this.rentals = response;
    });
  }

  onDelete(rentalId) {
    this.alertify.confirm('Jeste li sigurni da želite obrisati ovaj Najam?', () => {
      this.rentalService.deleteOne(rentalId).subscribe(() => {
        this.alertify.success('Najam je uspješno obrisan');
        this.getAllRentals();
      }, error => {
        this.alertify.error('Pogreška pri brisanju Najma');
      });
    });
  }

  onAdd() {
    this.router.navigate(['rentals/new']);
  }

   onEdit(rentalId) {
    this.router.navigate(['rentals', rentalId]);
  }

}
