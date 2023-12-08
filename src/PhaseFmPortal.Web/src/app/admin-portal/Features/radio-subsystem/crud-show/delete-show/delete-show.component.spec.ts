import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteShowComponent } from './delete-show.component';

describe('DeleteShowComponent', () => {
  let component: DeleteShowComponent;
  let fixture: ComponentFixture<DeleteShowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteShowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
