import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PayFastCheckoutComponent } from './pay-fast-checkout.component';

describe('PayFastCheckoutComponent', () => {
  let component: PayFastCheckoutComponent;
  let fixture: ComponentFixture<PayFastCheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PayFastCheckoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PayFastCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
