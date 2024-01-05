import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { ProductCategory } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-category';

@Component({
  selector: 'app-edit-product-category',
  templateUrl: './edit-product-category.component.html',
  styleUrls: ['./edit-product-category.component.scss']
})
export class EditProductCategoryComponent implements OnInit {

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
    private ref:MatDialogRef<EditProductCategoryComponent>,
    private dialog: MatDialog)   {}
  ngOnInit(): void {
    this.GetProductCategoryById(this.ecommerceService.Id);
  }

  EditProductCategory(){
    this.ecommerceService.updateProductCategory(this.productCategory).subscribe({
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

  GetProductCategoryById(id:number){
    this.ecommerceService.getProductCategory(id).subscribe({
      next:(response)=>{
        this.productCategory =  response as ProductCategory
      }
    })
  }

  CloseEditModal(){
    this.ref.close();
  }

}
