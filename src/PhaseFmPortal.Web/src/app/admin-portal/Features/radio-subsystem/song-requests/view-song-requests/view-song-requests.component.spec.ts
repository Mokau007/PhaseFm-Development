import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSongRequestsComponent } from './view-song-requests.component';

describe('ViewSongRequestsComponent', () => {
  let component: ViewSongRequestsComponent;
  let fixture: ComponentFixture<ViewSongRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewSongRequestsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewSongRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
