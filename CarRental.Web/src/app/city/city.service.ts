import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { DetailResponse } from '../Shared/Response/DetailResponse';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { City } from './City';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  constructor(
    private http: HttpClient
    ) { }

  private readonly CITY_URL = 'cities';

    public getAll() {
      return this.http.get(environment.apiUrl + this.CITY_URL);
    }

    public getOne(cityId) {
      return this.http.get(environment.apiUrl + this.CITY_URL + '/' + cityId).pipe(
        map((raw: DetailResponse<City>) => {
          return raw.response;
        })
      );
    }

    public addOne(city) {
      return this.http.post(environment.apiUrl + this.CITY_URL, city);
    }

    public putOne(cityId, city) {
      return this.http.put(environment.apiUrl + this.CITY_URL + '/' + cityId, city);
    }

    public deleteOne(cityId) {
      return this.http.delete(environment.apiUrl + this.CITY_URL + '/' + cityId);
    }

    // public softDelete(cityId, city) {
    //   return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    // }

    //  public patch(city, cityId) {
    //    return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    //  }

    // ako nije poslao location.id onda http post
    // ako je poslao id onda http put
    public submit(city) {
      if (!city.id) {
        return this.addOne(city);
      }
      return this.putOne(city.id, city);
    }
}
