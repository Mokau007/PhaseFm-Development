import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RadioShowsComponent } from './radio-shows.component';

describe('RadioShowsComponent', () => {
  let component: RadioShowsComponent;
  let fixture: ComponentFixture<RadioShowsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RadioShowsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RadioShowsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
