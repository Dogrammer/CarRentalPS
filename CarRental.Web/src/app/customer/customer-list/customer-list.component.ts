import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {

  constructor(
    private customerService: CustomerService,
    private alertify: AlertifyService,
    private router: Router) { }

  customers: any;

  ngOnInit() {
    this.getAllCustomers();
  }

  getAllCustomers() {
    this.customerService.getAll().subscribe(response => {
      this.customers = response;
    });
  }

  onDelete(customerId) {
    this.alertify.confirm('Jeste li sigurni da želite obrisati ovog Korisnika?', () => {
      this.customerService.deleteOne(customerId).subscribe(() => {
        this.alertify.success('Korisnik je uspješno obrisan');
        this.getAllCustomers();
      }, error => {
        this.alertify.error('Pogreška pri brisanju Korisnika');
      });
    });
  }


  onAdd() {
    this.router.navigate(['customers/new']);
  }

   onEdit(customerId) {
    this.router.navigate(['customers', customerId]);
  }
}
