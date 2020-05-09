import { Component, OnInit, ContentChildren, QueryList, ContentChild, Input } from '@angular/core';
import { WizardStepDirective } from '../wizard-step.directive';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'hrcn-wizard',
  templateUrl: './wizard.component.html',
  styleUrls: ['./wizard.component.scss']
})
export class WizardComponent implements OnInit {
  @Input() valideerStappen: boolean

  @ContentChildren(WizardStepDirective) readonly stappen: QueryList<WizardStepDirective>;
  @ContentChild(NgForm) form: NgForm;

  constructor() { }

  ngOnInit(): void {
  }
}
