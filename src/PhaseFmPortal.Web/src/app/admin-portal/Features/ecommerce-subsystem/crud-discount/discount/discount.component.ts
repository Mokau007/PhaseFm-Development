import { Component, OnInit, ViewChild } from '@angular/core';
import { Discount } from 'src/app/admin-portal/Shared/Models/Ecommerce/discount';
import { AddDiscountComponent } from '../add-discount/add-discount.component';
import { EditDiscountComponent } from '../edit-discount/edit-discount.component';
import { DeleteDiscountComponent } from '../delete-discount/delete-discount.component';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';

@Component({
  selector: 'app-discount',
  templateUrl: './discount.component.html',
  styleUrls: ['./discount.component.scss']
})
export class DiscountComponent implements OnInit {

  discount: Discount[] = [];

  datasource: any;
  displayedColumns: string[] = ["Percentage", "Edit", "Delete"];
  @ViewChild(MatPaginator) paginator!: MatPaginator; 

  @ViewChild(MatSort) sort!: MatSort; 
  constructor(
    private ecommerceService: EcommerceService,
    private dialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  ngOnInit(): void {
    this.GetAllDiscount();
  }

  GetAllDiscount() {
    this.ecommerceService
      .getAllDiscount()
      .subscribe((result: Discount[]) => {
        this.discount = result;
        this.datasource = new MatTableDataSource<Discount>(this.discount);
        this.datasource.paginator = this.paginator;
      });
  }

  EditDiscount(id: number) {
    this.ecommerceService.Id = id;
  }

  RequestToDeleteDiscount(id: number) {
    this.ecommerceService.Id = id;
    
  }

  OpenModal() {
    const ref = this.dialog.open(AddDiscountComponent, {
      width: "50%",
      height: "auto",
    });
    ref.afterClosed().subscribe(() => {
      this.GetAllDiscount();
    });
  }

  OpenEditModal() {
    const ref = this.dialog.open(EditDiscountComponent, {
      width: "50%",
      height: "auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllDiscount();
    });
  }

  OpenDeleteModal() {
    const ref = this.dialog.open(DeleteDiscountComponent, {
      width: "30%",
      height: "Auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllDiscount();
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
