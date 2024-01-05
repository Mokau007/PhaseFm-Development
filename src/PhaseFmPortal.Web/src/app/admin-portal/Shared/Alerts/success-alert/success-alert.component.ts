import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-success-alert',
  templateUrl: './success-alert.component.html',
  styleUrls: ['./success-alert.component.scss']
})
export class SuccessAlertComponent {

  errorMessage!: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,private ref:MatDialogRef<SuccessAlertComponent>)   {}

  CloseModal(){
    this.ref.close();
  }

}
