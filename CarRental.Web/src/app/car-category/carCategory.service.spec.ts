/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CarCategoryService } from './carCategory.service';

describe('Service: CarCategory', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CarCategoryService]
    });
  });

  it('should ...', inject([CarCategoryService], (service: CarCategoryService) => {
    expect(service).toBeTruthy();
  }));
});
