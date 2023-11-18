import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhaseFmNavbarComponent } from './phase-fm-navbar.component';

describe('PhaseFmNavbarComponent', () => {
  let component: PhaseFmNavbarComponent;
  let fixture: ComponentFixture<PhaseFmNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhaseFmNavbarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhaseFmNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
