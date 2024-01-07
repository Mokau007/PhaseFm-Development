import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { VAT } from 'src/app/admin-portal/Shared/Models/Ecommerce/vat';

@Component({
  selector: 'app-edit-vat',
  templateUrl: './edit-vat.component.html',
  styleUrls: ['./edit-vat.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class EditVatComponent implements OnInit {

  vat: VAT={
    id: 0,
    percentage: 0,
    isActive: false
  }

  errorMessage: string = '';
  showError!: boolean;
  
  responseMessage: any;

  constructor(
    private ecommerceService: EcommerceService,
    private router:Router,
    private ref:MatDialogRef<EditVatComponent>,
    private dialog: MatDialog)   {}

  ngOnInit(): void {
    this.GetVat(this.ecommerceService.Id);
  }

  EditVat(){
    this.ecommerceService.updateVat(this.vat).subscribe({
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

  GetVat(id:number){
    this.ecommerceService.getVat(id).subscribe({
      next:(response)=>{
        this.vat =  response as VAT
      }
    })
  }

  CloseEditModal(){
    this.ref.close();
  }
}
