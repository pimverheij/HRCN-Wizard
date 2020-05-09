import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WizardComponent } from './wizard/wizard.component';
import { WizardStepDirective } from './wizard-step.directive';
import { MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { PipeModule } from '../pipes/pipe.module';



@NgModule({
  declarations: [WizardComponent, WizardStepDirective],
  imports: [
    CommonModule,
    MatStepperModule,
    MatButtonModule,
    FormsModule,
    PipeModule
  ],
  exports: [WizardComponent, WizardStepDirective] 
})
export class WizardModule { }
