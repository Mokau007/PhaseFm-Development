import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ParentService } from '../parent.service';
import { Color } from 'src/app/admin-portal/Shared/Models/Ecommerce/color';
import { Product } from 'src/app/admin-portal/Shared/Models/Ecommerce/product';
import { ProductCategory } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-category';
import { ProductType } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-type';
import { Size } from 'src/app/admin-portal/Shared/Models/Ecommerce/size';
import { ProductSize } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-size';
import { ProductColor } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-color';

@Injectable({
  providedIn: 'root'
})
export class EcommerceService {

  constructor(private parentService: ParentService, private httpClient: HttpClient) { }


  // CRUD Product  endpoint requests
  private Product_Endpoint = 'product';
  public  Id! : number;

  getAllProduct() {
    return this.parentService.get<Product[]>(this.Product_Endpoint);
  }

  getProduct(product_ID: number) {
    return this.parentService.get<Product>(this.Product_Endpoint, product_ID);
  }

  createProduct(file: FormData) {
    return this.parentService.create<FormData>(this.Product_Endpoint, file);
  }

  deleteProduct(Id: number) {
    return this.parentService.delete<Product>(`${this.Product_Endpoint}/${Id}`);
  }

  updateProduct(file: FormData) {
    return this.parentService.update<FormData>(`${this.Product_Endpoint}/${this.Id}`, file);
  }

  
  // CRUD ProductCategory  endpoint requests
  private ProductCatgeory_Endpoint = 'productcategory';
  getAllProductCategory() {
    return this.parentService.get<ProductCategory[]>(this.ProductCatgeory_Endpoint);
  }

  getProductCategory(Id: number) {
    return this.parentService.get<ProductCategory>(this.ProductCatgeory_Endpoint, Id);
  }

  createProductCategory(ProductCategory: ProductCategory) {
    return this.parentService.create<ProductCategory>(this.ProductCatgeory_Endpoint, ProductCategory)
 
  }

  deleteProductCategory(Id: number) {
    return this.parentService.delete<ProductCategory>(`${this.ProductCatgeory_Endpoint}/${Id}`);
  }

  updateProductCategory(ProductCategory: ProductCategory) {
    return this.parentService.update<ProductCategory>(`${this.ProductCatgeory_Endpoint}/${ProductCategory.id}`, ProductCategory);
  }

  // CRUD ProductCategory  endpoint requests
  private ProductType_Endpoint = 'producttype';
  getAllProductType() {
    return this.parentService.get<ProductType[]>(this.ProductType_Endpoint);
  }

  getProductType(Id: number) {
    return this.parentService.get<ProductType>(this.ProductType_Endpoint, Id);
  }

  createProductType(productType: ProductType) {
    return this.parentService.create<ProductType>(this.ProductType_Endpoint, productType);
  }

  deleteProductType(Id: number) {
    return this.parentService.delete<ProductType>(`${this.ProductType_Endpoint}/${Id}`);
  }

  updateProductType(productType: ProductType) {
    return this.parentService.update<ProductType>(`${this.ProductType_Endpoint}/${productType.id}`, productType);
  }

   // CRUD Color  endpoint requests
   private Color_Endpoint = 'color';
   getAllColor() {
     return this.parentService.get<Color[]>(this.Color_Endpoint);
   }
 
   getColor(Id: number) {
     return this.parentService.get<Color>(this.Color_Endpoint, Id);
   }
 
   createColor(color: Color) {
     return this.parentService.create<Color>(this.Color_Endpoint, color);
   }
 
   deleteColor(Id: number) {
     return this.parentService.delete<Color>(`${this.Color_Endpoint}/${Id}`);
   }
 
   updateColor(color: Color) {
     return this.parentService.update<Color>(`${this.Color_Endpoint}/${color.id}`, color);
   }

   
   // CRUD Size  endpoint requests
   private Size_Endpoint = 'size';
   getAllSize() {
     return this.parentService.get<Size[]>(this.Size_Endpoint);
   }
 
   getSize(Id: number) {
     return this.parentService.get<Size>(this.Size_Endpoint, Id);
   }
 
   createSize(size: Size) {
     return this.parentService.create<Size>(this.Size_Endpoint, size);
   }
 
   deleteSize(Id: number) {
     return this.parentService.delete<Size>(`${this.Size_Endpoint}/${Id}`);
   }
 
   updateSize(size: Size) {
     return this.parentService.update<Size>(`${this.Size_Endpoint}/${size.id}`, size);
   }

   // CRUD ProductSize  endpoint requests
   private ProductSize_Endpoint = 'productsize';
   getAllProductSize() {
     return this.parentService.get<ProductSize[]>(this.ProductSize_Endpoint);
   }
 
   getProductSize(Id: number) {
     return this.parentService.get<ProductSize>(this.ProductSize_Endpoint, Id);
   }
 
   createProductSize(productSize: ProductSize) {
     return this.parentService.create<ProductSize>(this.ProductSize_Endpoint, productSize);
   }
 
   deleteProductSize(Id: number) {
     return this.parentService.delete<ProductSize>(`${this.ProductSize_Endpoint}/${Id}`);
   }
 
   updateProductSize(productSize: ProductSize) {
     return this.parentService.update<ProductSize>(`${this.ProductSize_Endpoint}/${productSize.id}`, productSize);
   }

   // CRUD ProductColor  endpoint requests
   private ProductColor_Endpoint = 'productsize';
   getAllProductColor() {
     return this.parentService.get<Size[]>(this.ProductColor_Endpoint);
   }
 
   getProductColor(Id: number) {
     return this.parentService.get<Size>(this.ProductColor_Endpoint, Id);
   }
 
   createProductColor(productColor: ProductColor) {
     return this.parentService.create<ProductColor>(this.ProductColor_Endpoint, productColor);
   }
 
   deleteProductColor(Id: number) {
     return this.parentService.delete<ProductColor>(`${this.ProductColor_Endpoint}/${Id}`);
   }
 
   updateProductColor(productColor: ProductColor) {
     return this.parentService.update<ProductColor>(`${this.ProductColor_Endpoint}/${productColor.id}`, productColor);
   }

  }