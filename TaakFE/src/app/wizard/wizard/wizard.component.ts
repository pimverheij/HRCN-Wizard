import { Component, OnInit, ContentChildren, QueryList, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { WizardStapComponent } from '../wizard-stap/wizard-stap.component';
import { ActivatedRoute, Router } from '@angular/router';
import { TaakService, Taak, TaakType } from '../taak.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/dialogs/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'hrcn-wizard',
  templateUrl: './wizard.component.html',
  styleUrls: ['./wizard.component.scss'],
})
export class WizardComponent implements OnInit {
 
  TaakType = TaakType;
  
  @Input() valideerStappen: boolean
  @Input() controleEnAkkoordUitklapbaar: boolean
  @Input() model: any
  @Output() updateModelEvent: EventEmitter<any> = new EventEmitter<any>();

  @ContentChildren(WizardStapComponent) readonly stappen: QueryList<WizardStapComponent>;
  taak: Taak;

  constructor(private service: TaakService, 
    private route: ActivatedRoute, 
    public dialog: MatDialog, 
    private router: Router) { }

  openDialogStopTaak(): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: {titel: 'Stoppen', content: 'Weet je zeker dat wilt stoppen met deze taak? De taak wordt opgeslagen.', buttonText: 'Stoppen'}
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result === 'confirm'){
        this.service.slaTaakOp(this.taak.id, this.model);
        this.router.navigate(['']);
      }
    });
  }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');

    this.service.getTaak(id).subscribe(result => {
      if(result.taakData)
        this.updateModelEvent.emit(result.taakData);
      this.taak = result
    });
  }

  stopTaak() {
    this.openDialogStopTaak();
  }
}
