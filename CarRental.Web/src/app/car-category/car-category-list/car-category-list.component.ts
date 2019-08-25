import { Component, OnInit } from '@angular/core';
import { CarCategoryService } from '../carCategory.service';
import { AlertifyService } from 'src/app/alertifyService/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-car-category-list',
  templateUrl: './car-category-list.component.html',
  styleUrls: ['./car-category-list.component.scss']
})
export class CarCategoryListComponent implements OnInit {

  constructor(
    private categoryService: CarCategoryService,
    private alertify: AlertifyService,
    private router: Router) { }

  categories: any;

  ngOnInit() {
    this.getAllCategories();
  }

  getAllCategories() {
    this.categoryService.getAll().subscribe(response => {
      this.categories = response;
    });
  }

  onDelete(categoryId) {
    this.alertify.confirm('Jeste li sigurni da želite obrisati ovu Kategoriju Vozila?', () => {
      this.categoryService.deleteOne(categoryId).subscribe(() => {
        this.alertify.success('Kategorija Vozila je uspješno obrisana');
        this.getAllCategories();
      }, error => {
        this.alertify.error('Pogreška pri brisanju Kategorije Vozila');
      });
    });
  }


  onAdd() {
    this.router.navigate(['carCategories/new']);
  }

   onEdit(categoryId) {
    this.router.navigate(['carCategories', categoryId]);
  }

  // softDelete(cityId) {
  //   if (confirm('Da li ste sigurni?')) {
  //       return this.cityService.patch( { op: 'replace', path: '/isDeleted', value: true }, cityId).subscribe(response => {
  //         this.alertify.success('jeeeej');
  //       });
  //   }

  // }
}
