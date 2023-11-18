import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersPendingComponent } from './orders-pending.component';

describe('OrdersPendingComponent', () => {
  let component: OrdersPendingComponent;
  let fixture: ComponentFixture<OrdersPendingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdersPendingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrdersPendingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
