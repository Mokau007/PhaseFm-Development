import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditVatComponent } from './edit-vat.component';

describe('EditVatComponent', () => {
  let component: EditVatComponent;
  let fixture: ComponentFixture<EditVatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditVatComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditVatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
