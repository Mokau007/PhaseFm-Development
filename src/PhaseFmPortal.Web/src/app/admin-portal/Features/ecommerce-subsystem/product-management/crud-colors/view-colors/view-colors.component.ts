import { Component, OnInit, ViewChild } from '@angular/core';
import { Color } from 'src/app/admin-portal/Shared/Models/Ecommerce/color';
import { AddColorComponent } from '../add-color/add-color.component';
import { EditColorComponent } from '../edit-color/edit-color.component';
import { DeleteColorsComponent } from '../delete-colors/delete-colors.component';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';

@Component({
  selector: 'app-view-colors',
  templateUrl: './view-colors.component.html',
  styleUrls: ['./view-colors.component.scss']
})
export class ViewColorsComponent implements OnInit {

  color: Color[] = [];

  datasource: any;
  displayedColumns: string[] = ["Name", "ColorCode", "Edit", "Delete"];
  @ViewChild(MatPaginator) paginator!: MatPaginator; 

  @ViewChild(MatSort) sort!: MatSort; 
  constructor(
    private ecommerceService: EcommerceService,
    private dialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  ngOnInit(): void {
    this.GetAllColor();
  }

  GetAllColor() {
    this.ecommerceService
      .getAllColor()
      .subscribe((result: Color[]) => {
        this.color = result;
        this.datasource = new MatTableDataSource<Color>(this.color);
        this.datasource.paginator = this.paginator;
      });
  }

  EditColor(id: number) {
    this.ecommerceService.Id = id;
  }

  RequestToDeleteColor(id: number) {
    this.ecommerceService.Id = id;
    
  }

  OpenModal() {
    const ref = this.dialog.open(AddColorComponent, {
      width: "80%",
      height: "auto",
    });
    ref.afterClosed().subscribe(() => {
      this.GetAllColor();
    });
  }

  OpenEditModal() {
    const ref = this.dialog.open(EditColorComponent, {
      width: "80%",
      height: "auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllColor();
    });
  }

  OpenDeleteModal() {
    const ref = this.dialog.open(DeleteColorsComponent, {
      width: "30%",
      height: "Auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllColor();
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
