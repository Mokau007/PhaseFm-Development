import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { Size } from 'src/app/admin-portal/Shared/Models/Ecommerce/size';

@Component({
  selector: 'app-edit-size',
  templateUrl: './edit-size.component.html',
  styleUrls: ['./edit-size.component.scss'],
  encapsulation: ViewEncapsulation.None,

})
export class EditSizeComponent implements OnInit {

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
    private ref:MatDialogRef<EditSizeComponent>,
    private dialog: MatDialog)   {}

  ngOnInit(): void {
    this.GetSizeById(this.ecommerceService.Id);
  }

  EditSize(){
    this.ecommerceService.updateSize(this.size).subscribe({
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

  GetSizeById(id:number){
    this.ecommerceService.getSize(id).subscribe({
      next:(response)=>{
        this.size =  response as Size
      }
    })
  }

  CloseEditModal(){
    this.ref.close();
  }

}
