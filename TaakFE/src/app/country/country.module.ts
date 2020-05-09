import { NgModule } from '@angular/core';
import { CountryComponent } from './country/country.component';
import { CountryRoutingModule } from './country-routing.module';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSelectModule } from '@angular/material/select'
import { WizardModule } from '../wizard/wizard.module';
import { CountryService } from './country.service';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [CountryComponent],
  providers: [CountryService],
  imports: [
    CommonModule,
    CountryRoutingModule,
    MatStepperModule,
    WizardModule,
    MatSelectModule
  ]
})
export class CountryModule {

}