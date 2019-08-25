import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { DetailResponse } from '../Shared/Response/DetailResponse';
import { CarCategory } from './CarCategory';

@Injectable({
  providedIn: 'root'
})
export class CarCategoryService {

  constructor(
    private http: HttpClient
    ) { }

  private readonly CATEGORY_URL = 'carCategories';

    public getAll() {
      return this.http.get(environment.apiUrl + this.CATEGORY_URL);
    }

    public getOne(categoryId) {
      return this.http.get(environment.apiUrl + this.CATEGORY_URL + '/' + categoryId).pipe(
        map((raw: DetailResponse<CarCategory>) => {
          return raw.response;
        })
      );
    }

    public addOne(category) {
      return this.http.post(environment.apiUrl + this.CATEGORY_URL, category);
    }

    public putOne(categoryId, category) {
      return this.http.put(environment.apiUrl + this.CATEGORY_URL + '/' + categoryId, category);
    }

    public deleteOne(categoryId) {
      return this.http.delete(environment.apiUrl + this.CATEGORY_URL + '/' + categoryId);
    }

    // public softDelete(cityId, city) {
    //   return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    // }

    //  public patch(city, cityId) {
    //    return this.http.patch(environment.apiUrl + this.CITY_URL + '/' + cityId, city);

    //  }

    // ako nije poslao location.id onda http post
    // ako je poslao id onda http put
    public submit(category) {
      if (!category.id) {
        return this.addOne(category);
      }
      return this.putOne(category.id, category);
    }
}
