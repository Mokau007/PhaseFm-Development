import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveSongRequestComponent } from './approve-song-request.component';

describe('ApproveSongRequestComponent', () => {
  let component: ApproveSongRequestComponent;
  let fixture: ComponentFixture<ApproveSongRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproveSongRequestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApproveSongRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
