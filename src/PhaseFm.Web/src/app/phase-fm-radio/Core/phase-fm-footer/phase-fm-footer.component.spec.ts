import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhaseFmFooterComponent } from './phase-fm-footer.component';

describe('PhaseFmFooterComponent', () => {
  let component: PhaseFmFooterComponent;
  let fixture: ComponentFixture<PhaseFmFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhaseFmFooterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhaseFmFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
