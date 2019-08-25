import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../customer.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.scss']
})
export class CustomerFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService,
    private router: Router,
    private alertify: AlertifyService
  ) { }

  public customer: any = {};
  public errorMessage = '';

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      const customerId = params.id;
      this.getCustomer(customerId);
      if (customerId != null) {
        this.getCustomer(customerId);
      }
    });
  }
  getCustomers() {
     this.customerService.getAll().subscribe(response => {
       this.customer = response;
     });
  }


  onSubmit() {
    this.customer.customerId = 1;
    this.customerService.submit(this.customer).subscribe(
      (response: any) => {
        this.alertify.success('Success');
        this.router.navigate(['customers']);
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
      });
  }

  getCustomer(customerId) {
    this.customerService.getOne(customerId).subscribe(response => {
      this.customer = response;
      this.customer.id = customerId;
      // this.car.id = carId;
    });

  }

  cancelForm() {
    this.router.navigate(['customers']);
  }
}
