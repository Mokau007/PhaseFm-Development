import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VatComponent } from './vat.component';

describe('VatComponent', () => {
  let component: VatComponent;
  let fixture: ComponentFixture<VatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VatComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
