import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewColorsComponent } from './view-colors.component';

describe('ViewColorsComponent', () => {
  let component: ViewColorsComponent;
  let fixture: ComponentFixture<ViewColorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewColorsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewColorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
