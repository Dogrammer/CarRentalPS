import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { DetailResponse } from '../Shared/Response/DetailResponse';
import { Location } from './Location';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(
    private http: HttpClient
    ) { }

  private readonly LOCATIONS_URL = 'locations';

    public getAll() {
      return this.http.get(environment.apiUrl + this.LOCATIONS_URL);
    }

    public getOne(locationId) {
      return this.http.get(environment.apiUrl + this.LOCATIONS_URL + '/' + locationId).pipe(
        map((raw: DetailResponse<Location>) => {
          return raw.response;
        })
      );
    }

    public addOne(location) {
      return this.http.post(environment.apiUrl + this.LOCATIONS_URL, location).pipe(
        map((raw: DetailResponse<Location>) => {
          return raw.response;
        })
      );
    }

    public putOne(locationId, location) {
      return this.http.put(environment.apiUrl + this.LOCATIONS_URL + '/' + locationId, location);
    }

    public deleteOne(locationId) {
      return this.http.delete(environment.apiUrl + this.LOCATIONS_URL + '/' + locationId);
    }

    // ako nije poslao location.id onda http post
    // ako je poslao id onda http put
    public submit(location) {
      if (!location.id) {
        return this.addOne(location);
      }
      return this.putOne(location.id, location);
    }
}
