import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../models/pagination';
import { map } from 'rxjs/operators';
import { DetailResponse } from '../Shared/Response/DetailResponse';
import { Rental } from './Rental';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  constructor(
    private http: HttpClient
    ) { }

  private readonly RENTAL_URL = 'rentals';

  public getAll() {
    return this.http.get(environment.apiUrl + this.RENTAL_URL);
  }

    // public getAll(page?, itemsPerPage?) {
    //   const paginatedResult: PaginatedResult<Rental[]> = new PaginatedResult<Rental[]>();

    //   let params = new HttpParams();

    //   if (page != null && itemsPerPage != null) {
    //     params = params.append('pageNumber', page);
    //     params = params.append('pageSize', itemsPerPage);
    //   }

    //   return this.http.get(environment.apiUrl + this.RENTAL_URL);
    // }

    public getOne(rentalId) {
      return this.http.get(environment.apiUrl + this.RENTAL_URL + '/' + rentalId).pipe(
        map((raw: DetailResponse<Rental>) => {
          return raw.response;
        })
      );
    }

    public addOne(rental) {
      return this.http.post(environment.apiUrl + this.RENTAL_URL, rental);
    }

    public putOne(rentalId, rental) {
      return this.http.put(environment.apiUrl + this.RENTAL_URL + '/' + rentalId, rental);
    }

    public deleteOne(rentalId) {
      return this.http.delete(environment.apiUrl + this.RENTAL_URL + '/' + rentalId);
    }

    // public softDelete(cityId, city) {
    //   return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    // }

    //  public patch(city, cityId) {
    //    return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    //  }

    // ako nije poslao location.id onda http post
    // ako je poslao id onda http put
    public submit(rental) {
      if (!rental.id) {
        return this.addOne(rental);
      }
      return this.putOne(rental.id, rental);
    }

}


