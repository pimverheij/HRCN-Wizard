import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WizardStapComponent } from './wizard-stap.component';

describe('WizardStapComponent', () => {
  let component: WizardStapComponent;
  let fixture: ComponentFixture<WizardStapComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WizardStapComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WizardStapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
