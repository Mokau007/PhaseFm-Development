import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDeliveryAddressComponent } from './edit-delivery-address.component';

describe('EditDeliveryAddressComponent', () => {
  let component: EditDeliveryAddressComponent;
  let fixture: ComponentFixture<EditDeliveryAddressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditDeliveryAddressComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditDeliveryAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
