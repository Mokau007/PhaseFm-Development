import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAdvertsComponent } from './view-adverts.component';

describe('ViewAdvertsComponent', () => {
  let component: ViewAdvertsComponent;
  let fixture: ComponentFixture<ViewAdvertsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAdvertsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewAdvertsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
