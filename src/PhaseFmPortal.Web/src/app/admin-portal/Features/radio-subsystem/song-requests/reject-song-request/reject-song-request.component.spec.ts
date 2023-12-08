import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RejectSongRequestComponent } from './reject-song-request.component';

describe('RejectSongRequestComponent', () => {
  let component: RejectSongRequestComponent;
  let fixture: ComponentFixture<RejectSongRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RejectSongRequestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RejectSongRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
