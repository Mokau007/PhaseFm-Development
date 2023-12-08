import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveMusicSubmissionComponent } from './approve-music-submission.component';

describe('ApproveMusicSubmissionComponent', () => {
  let component: ApproveMusicSubmissionComponent;
  let fixture: ComponentFixture<ApproveMusicSubmissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproveMusicSubmissionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApproveMusicSubmissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
