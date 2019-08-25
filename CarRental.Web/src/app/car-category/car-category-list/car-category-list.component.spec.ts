import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarCategoryListComponent } from './car-category-list.component';

describe('CarCategoryListComponent', () => {
  let component: CarCategoryListComponent;
  let fixture: ComponentFixture<CarCategoryListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarCategoryListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarCategoryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
