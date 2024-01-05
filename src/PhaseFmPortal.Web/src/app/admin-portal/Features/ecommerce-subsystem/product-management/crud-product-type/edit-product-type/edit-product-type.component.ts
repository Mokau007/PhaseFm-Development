import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { ProductCategory } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-category';
import { ProductType } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-type';
import { AddProductTypeComponent } from '../add-product-type/add-product-type.component';

@Component({
  selector: 'app-edit-product-type',
  templateUrl: './edit-product-type.component.html',
  styleUrls: ['./edit-product-type.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class EditProductTypeComponent implements OnInit {

  productType: ProductType={
    id: 0,
    name: "",
    description: "",
    categoryName: "null",
    productCategoryId: 0
  }

  productCategory: ProductCategory[]=[];

  errorMessage: string = '';
  showError!: boolean;
  
  responseMessage: any;

  constructor(
    private ecommerceService: EcommerceService,
    private router:Router,
    private ref:MatDialogRef<AddProductTypeComponent>,
    private dialog: MatDialog)   {}
    
  ngOnInit(): void {
    this.GetAllProductCategory();
    this.GetProductType(this.ecommerceService.Id);
    console.log(this.ecommerceService.Id)
  }

  EditProductType(){
    this.ecommerceService.updateProductType(this.productType).subscribe({
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

  GetAllProductCategory(){
    this.ecommerceService
    .getAllProductCategory()
    .subscribe((result: ProductCategory[]) => {
      this.productCategory = result;
      
    });
  }

  GetProductType(id: number){
    this.ecommerceService
    .getProductType(id)
    .subscribe((result) => {
      this.productType = result as ProductType;
      
    });
  }

  SelectProductCategory(value: any){
    const id=value;
    this.productType.productCategoryId=parseInt(id);
  }

  CloseEditModal(){
    this.ref.close();
  }
  
}
