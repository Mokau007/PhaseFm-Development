import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSizesComponent } from './view-sizes.component';

describe('ViewSizesComponent', () => {
  let component: ViewSizesComponent;
  let fixture: ComponentFixture<ViewSizesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewSizesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewSizesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
