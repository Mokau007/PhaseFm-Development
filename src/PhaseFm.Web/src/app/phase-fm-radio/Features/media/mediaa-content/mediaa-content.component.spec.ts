import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaaContentComponent } from './mediaa-content.component';

describe('MediaaContentComponent', () => {
  let component: MediaaContentComponent;
  let fixture: ComponentFixture<MediaaContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MediaaContentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MediaaContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
