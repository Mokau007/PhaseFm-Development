import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewArticlesComponent } from './view-articles.component';

describe('ViewArticlesComponent', () => {
  let component: ViewArticlesComponent;
  let fixture: ComponentFixture<ViewArticlesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewArticlesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewArticlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
