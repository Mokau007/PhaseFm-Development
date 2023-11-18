import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderManagementTabsComponent } from './order-management-tabs.component';

describe('OrderManagementTabsComponent', () => {
  let component: OrderManagementTabsComponent;
  let fixture: ComponentFixture<OrderManagementTabsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderManagementTabsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderManagementTabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
