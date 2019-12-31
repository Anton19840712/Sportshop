import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SubClassFormComponent } from './subclass-form.component';

describe('ClassSectionFormComponent', () => {
  let component: SubClassFormComponent;
  let fixture: ComponentFixture<SubClassFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubClassFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubClassFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
