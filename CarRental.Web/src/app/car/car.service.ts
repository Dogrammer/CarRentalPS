import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Car } from './Car';
import { DetailResponse } from '../Shared/Response/DetailResponse';


@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor(
    private http: HttpClient
    ) { }

  private readonly CAR_URL = 'cars';

    public getAll() {
      return this.http.get(environment.apiUrl + this.CAR_URL);
    }

    public getOne(carId) {
      return this.http.get(environment.apiUrl + this.CAR_URL + '/' + carId).pipe(
        map((raw: DetailResponse<Car>) => {
          return raw.response;
        })
      );
    }

    public addOne(car) {
      return this.http.post(environment.apiUrl + this.CAR_URL, car);
    }

    public putOne(carId, car) {
      return this.http.put(environment.apiUrl + this.CAR_URL + '/' + carId, car);
    }

    public deleteOne(carId) {
      return this.http.delete(environment.apiUrl + this.CAR_URL + '/' + carId);
    }

    // public softDelete(cityId, city) {
    //   return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    // }

    //  public patch(city, cityId) {
    //    return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    //  }

    // ako nije poslao location.id onda http post
    // ako je poslao id onda http put
    public submit(car) {
      if (!car.id) {
        return this.addOne(car);
      }
      return this.putOne(car.id, car);
    }

}
