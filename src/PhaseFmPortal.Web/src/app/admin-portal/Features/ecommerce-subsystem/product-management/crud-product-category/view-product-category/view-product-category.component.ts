import { Component, OnInit, ViewChild } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { EcommerceService } from "src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service";
import { ProductCategory } from "src/app/admin-portal/Shared/Models/Ecommerce/product-category";
import { AddProductCategoryComponent } from "../add-product-category/add-product-category.component";
import { DeleteProductCategoryComponent } from "../delete-product-category/delete-product-category.component";
import { EditProductCategoryComponent } from "../edit-product-category/edit-product-category.component";
import { MatSort, Sort } from "@angular/material/sort";
import { LiveAnnouncer } from "@angular/cdk/a11y";
import { SuccessAlertComponent } from "src/app/admin-portal/Shared/Alerts/success-alert/success-alert.component";
import { ErrorAlertComponent } from "src/app/admin-portal/Shared/Alerts/error-alert/error-alert.component";

@Component({
  selector: "app-view-product-category",
  templateUrl: "./view-product-category.component.html",
  styleUrls: ["./view-product-category.component.scss"],
})
export class ViewProductCategoryComponent implements OnInit {
  productCategory: ProductCategory[] = [];

  datasource: any;
  displayedColumns: string[] = ["Name", "Description", "Edit", "Delete"];
  @ViewChild(MatPaginator) paginator!: MatPaginator; 

  @ViewChild(MatSort) sort!: MatSort; 
  constructor(
    private ecommerceService: EcommerceService,
    private dialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  ngOnInit(): void {
    this.GetProductCategory();
  }
  GetProductCategory() {
    this.ecommerceService
      .getAllProductCategory()
      .subscribe((result: ProductCategory[]) => {
        this.productCategory = result;
        this.datasource = new MatTableDataSource<ProductCategory>(this.productCategory);
        this.datasource.paginator = this.paginator;
      });
  }

  EditProductCategory(id: number) {
    this.ecommerceService.Id = id;
  }

  RequestToDeleteProductCategory(productCategory_Id: number) {
    this.ecommerceService.Id = productCategory_Id;
    
  }

  OpenModal() {
    const ref = this.dialog.open(AddProductCategoryComponent, {
      width: "80%",
      height: "auto",
    });
    ref.afterClosed().subscribe(() => {
      this.GetProductCategory();
    });
  }

  OpenEditModal() {
    const ref = this.dialog.open(EditProductCategoryComponent, {
      width: "80%",
      height: "auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetProductCategory();
    });
  }

  OpenDeleteModal() {
    const ref = this.dialog.open(DeleteProductCategoryComponent, {
      width: "30%",
      height: "Auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetProductCategory();
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
