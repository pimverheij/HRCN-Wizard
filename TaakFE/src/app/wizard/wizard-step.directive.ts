import { Directive, TemplateRef, Input } from '@angular/core';
import { Observable } from 'rxjs';

@Directive({
  selector: '[hrcnWizardStep]'
})
export class WizardStepDirective {

  @Input('hrcnWizardStep') title: string;

  constructor(
    readonly templateRef: TemplateRef<unknown>
  ) { }

}
