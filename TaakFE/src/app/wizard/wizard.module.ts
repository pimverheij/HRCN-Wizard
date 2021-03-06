import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WizardComponent } from './wizard/wizard.component';
import { WizardStepDirective } from './wizard-step.directive';
import { MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { PipeModule } from '../pipes/pipe.module';
import { MatCardModule } from '@angular/material/card';
import {MatExpansionModule} from '@angular/material/expansion';
import { WizardStapComponent } from './wizard-stap/wizard-stap.component';
import { WizardStapReadonlyComponent } from './wizard-stap-readonly/wizard-stap-readonly.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [WizardComponent, WizardStepDirective, WizardStapComponent, WizardStapReadonlyComponent],
  imports: [
    CommonModule,
    MatStepperModule,
    MatButtonModule,
    FormsModule,
    PipeModule,
    MatCardModule,
    MatExpansionModule,
    HttpClientModule
  ],
  exports: [WizardComponent, WizardStepDirective, WizardStapComponent] 
})
export class WizardModule { }
