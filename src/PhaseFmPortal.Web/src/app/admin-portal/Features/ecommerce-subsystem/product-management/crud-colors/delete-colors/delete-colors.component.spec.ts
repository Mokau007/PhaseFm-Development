import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteColorsComponent } from './delete-colors.component';

describe('DeleteColorsComponent', () => {
  let component: DeleteColorsComponent;
  let fixture: ComponentFixture<DeleteColorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteColorsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteColorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
