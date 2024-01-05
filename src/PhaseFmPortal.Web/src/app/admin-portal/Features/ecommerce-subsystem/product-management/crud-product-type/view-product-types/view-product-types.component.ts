import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { ProductCategory } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-category';
import { ProductType } from 'src/app/admin-portal/Shared/Models/Ecommerce/product-type';
import { AddProductCategoryComponent } from '../../crud-product-category/add-product-category/add-product-category.component';
import { DeleteProductCategoryComponent } from '../../crud-product-category/delete-product-category/delete-product-category.component';
import { EditProductCategoryComponent } from '../../crud-product-category/edit-product-category/edit-product-category.component';
import { AddProductTypeComponent } from '../add-product-type/add-product-type.component';
import { EditProductTypeComponent } from '../edit-product-type/edit-product-type.component';
import { DeleteProductTypeComponent } from '../delete-product-type/delete-product-type.component';

@Component({
  selector: 'app-view-product-types',
  templateUrl: './view-product-types.component.html',
  styleUrls: ['./view-product-types.component.scss']
})
export class ViewProductTypesComponent implements OnInit {

  productType: ProductType[] = [];

  datasource: any;
  displayedColumns: string[] = ["Name", "Description","ProductCatgory", "Edit", "Delete"];
  @ViewChild(MatPaginator) paginator!: MatPaginator; 

  @ViewChild(MatSort) sort!: MatSort; 
  constructor(
    private ecommerceService: EcommerceService,
    private dialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  ngOnInit(): void {
    this.GetProductType();
    
  }

  GetProductType() {
    this.ecommerceService
      .getAllProductType()
      .subscribe((result: ProductType[]) => {
        this.productType = result;
        this.datasource = new MatTableDataSource<ProductType>(this.productType);
        this.datasource.paginator = this.paginator;
      });
  }

  EditProductType(id: number) {
    this.ecommerceService.Id = id;
  }

  RequestToDeleteProductType(id: number) {
    this.ecommerceService.Id = id;
    
  }

  OpenModal() {
    const ref = this.dialog.open(AddProductTypeComponent, {
      width: "80%",
      height: "auto",
    });
    ref.afterClosed().subscribe(() => {
      this.GetProductType();
    });
  }

  OpenEditModal() {
    const ref = this.dialog.open(EditProductTypeComponent, {
      width: "80%",
      height: "auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetProductType();
    });
  }

  OpenDeleteModal() {
    const ref = this.dialog.open(DeleteProductTypeComponent, {
      width: "30%",
      height: "Auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetProductType();
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.datasource.filter = filterValue.trim().toLowerCase();
  }

  ngAfterViewInit() {
    this.datasource.sort = this.sort;
  }

  /** Announce the change in sort state for assistive technology. */
  announceSortChange(sortState: Sort) {
    // This example uses English messages. If your application supports
    // multiple language, you would internationalize these strings.
    // Furthermore, you can customize the message to add additional
    // details about the values being sorted.
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  toolTipText =
  "Welcome to Product Management! 1. To Add a new Product Category, click the Add Product Category button." +
  "2. To edit a product category, click the pen icon which is located in the table at the end of each line." +
 " 3. To delete a product category, click the bin icon which is loacted next to the pen icon.;"

}
