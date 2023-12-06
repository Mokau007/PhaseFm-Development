import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewShowsComponent } from './view-shows.component';

describe('ViewShowsComponent', () => {
  let component: ViewShowsComponent;
  let fixture: ComponentFixture<ViewShowsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewShowsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewShowsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
