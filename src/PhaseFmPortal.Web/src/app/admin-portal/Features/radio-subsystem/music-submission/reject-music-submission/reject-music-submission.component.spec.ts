import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RejectMusicSubmissionComponent } from './reject-music-submission.component';

describe('RejectMusicSubmissionComponent', () => {
  let component: RejectMusicSubmissionComponent;
  let fixture: ComponentFixture<RejectMusicSubmissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RejectMusicSubmissionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RejectMusicSubmissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
