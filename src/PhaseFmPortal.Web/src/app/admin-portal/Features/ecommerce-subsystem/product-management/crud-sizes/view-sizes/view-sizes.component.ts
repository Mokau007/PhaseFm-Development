import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { Size } from 'src/app/admin-portal/Shared/Models/Ecommerce/size';
import { AddSizeComponent } from '../add-size/add-size.component';
import { EditSizeComponent } from '../edit-size/edit-size.component';
import { DeleteSizeComponent } from '../delete-size/delete-size.component';

@Component({
  selector: 'app-view-sizes',
  templateUrl: './view-sizes.component.html',
  styleUrls: ['./view-sizes.component.scss'],
  
})
export class ViewSizesComponent implements OnInit{

  size: Size[] = [];

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
    this.GetAllSize();
  }

  GetAllSize() {
    this.ecommerceService
      .getAllSize()
      .subscribe((result: Size[]) => {
        this.size = result;
        this.datasource = new MatTableDataSource<Size>(this.size);
        this.datasource.paginator = this.paginator;
      });
  }

  EditSize(id: number) {
    this.ecommerceService.Id = id;
  }

  RequestToDeleteSize(id: number) {
    this.ecommerceService.Id = id;
    
  }

  OpenModal() {
    const ref = this.dialog.open(AddSizeComponent, {
      width: "80%",
      height: "auto",
    });
    ref.afterClosed().subscribe(() => {
      this.GetAllSize();
    });
  }

  OpenEditModal() {
    const ref = this.dialog.open(EditSizeComponent, {
      width: "80%",
      height: "auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllSize();
    });
  }

  OpenDeleteModal() {
    const ref = this.dialog.open(DeleteSizeComponent, {
      width: "30%",
      height: "Auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllSize();
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
