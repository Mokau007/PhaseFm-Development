import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteProductTypeComponent } from './delete-product-type.component';

describe('DeleteProductTypeComponent', () => {
  let component: DeleteProductTypeComponent;
  let fixture: ComponentFixture<DeleteProductTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteProductTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteProductTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
