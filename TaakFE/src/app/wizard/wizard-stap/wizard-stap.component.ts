import { Component, OnInit, Input, ViewChild, TemplateRef, ContentChild, ContentChildren, QueryList, ViewChildren, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { WizardStepDirective } from '../wizard-step.directive';
import { NgForm } from '@angular/forms';
import { MatFormField } from '@angular/material/form-field';

@Component({
  selector: 'hrcn-wizard-stap',
  templateUrl: './wizard-stap.component.html',
  styleUrls: ['./wizard-stap.component.scss'],
})
export class WizardStapComponent implements OnInit {
  @ViewChild(WizardStepDirective) readonly directive: WizardStepDirective;
  @ContentChild(NgForm) readonly form: NgForm;
  @ContentChildren(MatFormField, { descendants: true}) readonly formFields: QueryList<MatFormField>
  @Input() titel: string;
  @Input() overslaan: boolean;

  constructor(private cd: ChangeDetectorRef) { 
  }
  
  ngOnInit(): void {
  }
  
  ngAfterViewInit() : void {
  }

  ngAfterContentInit() {
     this.cd.detectChanges();
  }
}
