import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { DeliveryFee } from 'src/app/admin-portal/Shared/Models/Ecommerce/delivery-fee';

@Component({
  selector: 'app-edit-delivery',
  templateUrl: './edit-delivery.component.html',
  styleUrls: ['./edit-delivery.component.scss']
})
export class EditDeliveryComponent implements OnInit {

  deliveryFee: DeliveryFee={
    id: 0,
    price: 0,
    isActive: false
  }

  errorMessage: string = '';
  showError!: boolean;
  
  responseMessage: any;

  constructor(
    private ecommerceService: EcommerceService,
    private router:Router,
    private ref:MatDialogRef<EditDeliveryComponent>,
    private dialog: MatDialog)   {}

  ngOnInit(): void {
    this.GetDeliveryFee(this.ecommerceService.Id);
  }

  EditDeliveryFee(){
    this.ecommerceService.updateDelivery(this.deliveryFee).subscribe({
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

  GetDeliveryFee(id:number){
    this.ecommerceService.getDelivery(id).subscribe({
      next:(response)=>{
        this.deliveryFee =  response as DeliveryFee
      }
    })
  }

  CloseEditModal(){
    this.ref.close();
  }
}
