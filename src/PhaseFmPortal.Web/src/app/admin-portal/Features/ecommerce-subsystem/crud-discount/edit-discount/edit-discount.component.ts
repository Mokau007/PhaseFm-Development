import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { Discount } from 'src/app/admin-portal/Shared/Models/Ecommerce/discount';

@Component({
  selector: 'app-edit-discount',
  templateUrl: './edit-discount.component.html',
  styleUrls: ['./edit-discount.component.scss'],
  encapsulation:ViewEncapsulation.None
})
export class EditDiscountComponent implements OnInit {

  discount: Discount={
    id: 0,
    percentage: 0
  }

  errorMessage: string = '';
  showError!: boolean;
  
  responseMessage: any;

  constructor(
    private ecommerceService: EcommerceService,
    private router:Router,
    private ref:MatDialogRef<EditDiscountComponent>,
    private dialog: MatDialog)   {}

  ngOnInit(): void {
    this.GetDiscount(this.ecommerceService.Id);
  }

  EditDiscount(){
    this.ecommerceService.updateDiscount(this.discount).subscribe({
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

  GetDiscount(id:number){
    this.ecommerceService.getDiscount(id).subscribe({
      next:(response)=>{
        this.discount =  response as Discount
      }
    })
  }

  CloseEditModal(){
    this.ref.close();
  }
}
