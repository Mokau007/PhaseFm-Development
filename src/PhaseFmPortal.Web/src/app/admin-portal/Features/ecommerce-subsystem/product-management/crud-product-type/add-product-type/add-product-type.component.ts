import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { SuccessAlertComponent } from 'src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component';
import { ProductCategory } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-category';
import { ProductType } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-type';

@Component({
  selector: 'app-add-product-type',
  templateUrl: './add-product-type.component.html',
  styleUrls: ['./add-product-type.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class AddProductTypeComponent implements OnInit {

  productType: ProductType={
    id: 0,
    name: "",
    description: "",
    categoryName: '',
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
  }

  AddProductType(){
    this.ecommerceService.createProductType(this.productType).subscribe({
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

  SelectProductCategory(value: any){
    const id=value;
    this.productType.productCategoryId=parseInt(id);
  }

  CloseEditModal(){
    this.ref.close();
  }

}
