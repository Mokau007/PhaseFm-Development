import { HttpErrorResponse } from '@angular/common/http';
import { Component, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { Size } from 'src/app/admin-portal/Shared/Models/Ecommerce/size';

@Component({
  selector: 'app-add-size',
  templateUrl: './add-size.component.html',
  styleUrls: ['./add-size.component.scss'],
  encapsulation: ViewEncapsulation.None,

})
export class AddSizeComponent {

  size: Size={
    id:0,
    name:"",
    description:""
  }

  errorMessage: string = '';
  showError!: boolean;
  
  responseMessage: any;

  constructor(
    private ecommerceService: EcommerceService,
    private router:Router,
    private ref:MatDialogRef<AddSizeComponent>,
    private dialog: MatDialog)   {}

  AddSize(){
    this.ecommerceService.createSize(this.size).subscribe({
      next:(response:any)=>{
        this.ref.close();
        this.responseMessage = response.message;
        console.log(this.responseMessage)
        this.dialog.open(SuccessAlertComponent, {
          width: '40%',
          height: 'Auto',
          data:  this.responseMessage
        })
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.error;
        this.showError = true;

      }
    })
  }

  CloseEditModal(){
    this.ref.close();
  }
}
