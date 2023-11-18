import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitMusicComponent } from './submit-music.component';

describe('SubmitMusicComponent', () => {
  let component: SubmitMusicComponent;
  let fixture: ComponentFixture<SubmitMusicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubmitMusicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubmitMusicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
