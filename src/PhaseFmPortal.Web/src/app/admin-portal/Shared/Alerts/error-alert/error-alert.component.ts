import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-error-alert',
  templateUrl: './error-alert.component.html',
  styleUrls: ['./error-alert.component.scss']
})
export class ErrorAlertComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,private ref:MatDialogRef<ErrorAlertComponent>)   {}

  CloseModal(){
    this.ref.close();
  }

}
