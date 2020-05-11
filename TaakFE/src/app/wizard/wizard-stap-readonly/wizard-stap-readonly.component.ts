import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'hrcn-wizard-stap-readonly',
  templateUrl: './wizard-stap-readonly.component.html',
  styleUrls: ['./wizard-stap-readonly.component.scss']
})
export class WizardStapReadonlyComponent implements OnInit {
  @Input() form 

  get velden() : [string, string][] {
    return Object.entries<string>(this.form).filter(veld => veld[1] !== undefined);
  }

  constructor() { }

  ngOnInit(): void {
  }

}