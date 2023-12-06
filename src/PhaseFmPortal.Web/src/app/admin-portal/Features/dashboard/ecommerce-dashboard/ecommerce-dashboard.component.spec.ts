import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EcommerceDashboardComponent } from './ecommerce-dashboard.component';

describe('EcommerceDashboardComponent', () => {
  let component: EcommerceDashboardComponent;
  let fixture: ComponentFixture<EcommerceDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EcommerceDashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EcommerceDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
