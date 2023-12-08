import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PortalNavComponent } from './portal-nav.component';

describe('PortalNavComponent', () => {
  let component: PortalNavComponent;
  let fixture: ComponentFixture<PortalNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PortalNavComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PortalNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
