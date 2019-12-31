import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubClassListComponent } from './subclass-list.component';

describe('SubClassListComponent', () => {
  let component: SubClassListComponent;
  let fixture: ComponentFixture<SubClassListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubClassListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubClassListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
