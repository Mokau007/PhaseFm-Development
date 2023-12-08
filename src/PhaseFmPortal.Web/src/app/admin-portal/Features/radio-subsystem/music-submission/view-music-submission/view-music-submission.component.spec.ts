import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMusicSubmissionComponent } from './view-music-submission.component';

describe('ViewMusicSubmissionComponent', () => {
  let component: ViewMusicSubmissionComponent;
  let fixture: ComponentFixture<ViewMusicSubmissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewMusicSubmissionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewMusicSubmissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
