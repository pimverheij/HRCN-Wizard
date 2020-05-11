import { Directive, TemplateRef } from '@angular/core';

@Directive({
  selector: '[hrcnWizardStep]'
})
export class WizardStepDirective {
  constructor(readonly templateRef: TemplateRef<unknown>) { }

}
