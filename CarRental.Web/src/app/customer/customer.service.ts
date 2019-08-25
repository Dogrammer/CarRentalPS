import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { DetailResponse } from '../Shared/Response/DetailResponse';
import { City } from '../city/City';
import { Customer } from './Customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(
    private http: HttpClient
    ) { }

  private readonly CUSTOMER_URL = 'customers';

    public getAll() {
      return this.http.get(environment.apiUrl + this.CUSTOMER_URL);
    }

    public getOne(customerId) {
      return this.http.get(environment.apiUrl + this.CUSTOMER_URL + '/' + customerId);
    }

    public addOne(customer) {
      return this.http.post(environment.apiUrl + this.CUSTOMER_URL, customer).pipe(
        map((raw: DetailResponse<Customer>) => {
          return raw.response;
        })
      );
    }

    public putOne(customerId, customer) {
      return this.http.put(environment.apiUrl + this.CUSTOMER_URL + '/' + customerId, customer);
    }

    public deleteOne(customerId) {
      return this.http.delete(environment.apiUrl + this.CUSTOMER_URL + '/' + customerId);
    }

    // public softDelete(cityId, city) {
    //   return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    // }

    //  public patch(city, cityId) {
    //    return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    //  }

    // ako nije poslao location.id onda http post
    // ako je poslao id onda http put
    public submit(customer) {
      if (!customer.id) {
        return this.addOne(customer);
      }
      return this.putOne(customer.id, customer);
    }

}
