import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WizardStapReadonlyComponent } from './wizard-stap-readonly.component';

describe('WizardStapReadonlyComponent', () => {
  let component: WizardStapReadonlyComponent;
  let fixture: ComponentFixture<WizardStapReadonlyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WizardStapReadonlyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WizardStapReadonlyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
