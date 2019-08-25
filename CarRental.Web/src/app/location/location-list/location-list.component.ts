import { Component, OnInit } from '@angular/core';
import { LocationService } from '../location.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-location-list',
  templateUrl: './location-list.component.html',
  styleUrls: ['./location-list.component.scss']
})
export class LocationListComponent implements OnInit {

  constructor(
    private locationService: LocationService,
    private alertify: AlertifyService,
    private router: Router) { }

  locations: any;

  ngOnInit() {
    this.getAllLocations();
  }

  getAllLocations() {
    this.locationService.getAll().subscribe(response => {
      this.locations = response;
    });
  }

  onDelete(locationId) {
    this.alertify.confirm('Jeste li sigurni da želite obrisati ovu Lokaciju?', () => {
      this.locationService.deleteOne(locationId).subscribe(() => {
        this.alertify.success('Lokacija je uspješno obrisana');
        this.getAllLocations();
      }, error => {
        this.alertify.error('Pogreška pri brisanju Lokacije');
      });
    });
  }


  onAdd() {
    this.router.navigate(['locations/new']);
  }

   onEdit(locationId) {
    this.router.navigate(['locations', locationId]);
  }

}
