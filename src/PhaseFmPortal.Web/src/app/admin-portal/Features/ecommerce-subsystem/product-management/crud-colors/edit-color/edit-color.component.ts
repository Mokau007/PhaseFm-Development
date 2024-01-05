import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { Color } from 'src/app/admin-portal/Shared/Models/Ecommerce/color';

@Component({
  selector: 'app-edit-color',
  templateUrl: './edit-color.component.html',
  styleUrls: ['./edit-color.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class EditColorComponent implements OnInit {

  color: Color={
    id:0,
    name:"",
    colorCode:""
  }

  errorMessage: string = '';
  showError!: boolean;
  
  responseMessage: any;

  constructor(
    private ecommerceService: EcommerceService,
    private router:Router,
    private ref:MatDialogRef<EditColorComponent>,
    private dialog: MatDialog)   {}

  ngOnInit(): void {
    this.GetColorById(this.ecommerceService.Id);
  }

  EditColor(){
    this.ecommerceService.updateColor(this.color).subscribe({
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

  GetColorById(id:number){
    this.ecommerceService.getColor(id).subscribe({
      next:(response)=>{
        this.color =  response as Color
      }
    })
  }

  CloseEditModal(){
    this.ref.close();
  }
}
