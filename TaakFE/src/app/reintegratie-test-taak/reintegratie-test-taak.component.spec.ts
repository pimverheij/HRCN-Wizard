import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReintegratieTestTaakComponent } from './reintegratie-test-taak.component';

describe('ReintegratieTestTaakComponent', () => {
  let component: ReintegratieTestTaakComponent;
  let fixture: ComponentFixture<ReintegratieTestTaakComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReintegratieTestTaakComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReintegratieTestTaakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
