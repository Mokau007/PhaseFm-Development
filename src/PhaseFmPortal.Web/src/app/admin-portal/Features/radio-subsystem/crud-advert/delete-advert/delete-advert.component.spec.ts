import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteAdvertComponent } from './delete-advert.component';

describe('DeleteAdvertComponent', () => {
  let component: DeleteAdvertComponent;
  let fixture: ComponentFixture<DeleteAdvertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteAdvertComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteAdvertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
