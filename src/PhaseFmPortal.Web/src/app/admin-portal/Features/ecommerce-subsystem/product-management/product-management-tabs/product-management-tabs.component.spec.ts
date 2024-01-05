import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductManagementTabsComponent } from './product-management-tabs.component';

describe('ProductManagementTabsComponent', () => {
  let component: ProductManagementTabsComponent;
  let fixture: ComponentFixture<ProductManagementTabsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductManagementTabsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductManagementTabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
