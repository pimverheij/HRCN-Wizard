import { Component, OnInit, ContentChildren, QueryList, ContentChild, Input } from '@angular/core';
import { WizardStepDirective } from '../wizard-step.directive';
import { NgForm } from '@angular/forms';
import { WizardStapComponent } from '../wizard-stap/wizard-stap.component';

@Component({
  selector: 'hrcn-wizard',
  templateUrl: './wizard.component.html',
  styleUrls: ['./wizard.component.scss']
})
export class WizardComponent implements OnInit {
  @Input() valideerStappen: boolean
  @Input() controleEnAkkoordUitklapbaar: boolean

  @ContentChildren(WizardStapComponent) readonly stappen: QueryList<WizardStapComponent>;

  constructor() { }

  ngOnInit(): void {
  }

  ngAfterViewInit() : void {
    //debugger
    //console.log(this.stappen)
  }
}
