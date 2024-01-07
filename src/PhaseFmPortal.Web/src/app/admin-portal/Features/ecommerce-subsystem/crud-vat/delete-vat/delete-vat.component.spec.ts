import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteVatComponent } from './delete-vat.component';

describe('DeleteVatComponent', () => {
  let component: DeleteVatComponent;
  let fixture: ComponentFixture<DeleteVatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteVatComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteVatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
