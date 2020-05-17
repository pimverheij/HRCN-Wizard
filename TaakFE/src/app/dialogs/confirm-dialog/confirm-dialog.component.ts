import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'hrcn-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent { 
  constructor(
    public dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ConfirmDialogData) {}

  cancel(): void {
    this.dialogRef.close();
  }

  confirm(): void {
    this.dialogRef.close('confirm');
  }

}

export interface ConfirmDialogData {
  titel: string;
  content: string;
  buttonText: string;
}