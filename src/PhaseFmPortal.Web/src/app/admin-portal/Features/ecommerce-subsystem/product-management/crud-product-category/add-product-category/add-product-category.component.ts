import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { ProductCategory } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-category';

@Component({
  selector: 'app-add-product-category',
  templateUrl: './add-product-category.component.html',
  styleUrls: ['./add-product-category.component.scss']
})
export class AddProductCategoryComponent {

  productCategory: ProductCategory={
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
    private ref:MatDialogRef<AddProductCategoryComponent>,
    private dialog: MatDialog)   {}

  AddProductCategory(){
    this.ecommerceService.createProductCategory(this.productCategory).subscribe({
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
