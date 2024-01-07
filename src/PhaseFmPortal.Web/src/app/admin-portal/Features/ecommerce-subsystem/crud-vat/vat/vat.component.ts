import { Component, OnInit, ViewChild } from '@angular/core';
import { VAT } from 'src/app/admin-portal/Shared/Models/Ecommerce/vat';
import { AddVatComponent } from '../add-vat/add-vat.component';
import { EditVatComponent } from '../edit-vat/edit-vat.component';
import { DeleteVatComponent } from '../delete-vat/delete-vat.component';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';

@Component({
  selector: 'app-vat',
  templateUrl: './vat.component.html',
  styleUrls: ['./vat.component.scss']
})
export class VatComponent implements OnInit {

  vat: VAT[] = [];

  datasource: any;
  displayedColumns: string[] = ["Percentage", "Activate", "Edit", "Delete"];
  @ViewChild(MatPaginator) paginator!: MatPaginator; 

  @ViewChild(MatSort) sort!: MatSort; 
  constructor(
    private ecommerceService: EcommerceService,
    private dialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  ngOnInit(): void {
    this.GetAllVat();
  }

  GetAllVat() {
    this.ecommerceService
      .getAllVat()
      .subscribe((result: VAT[]) => {
        this.vat = result;
        this.datasource = new MatTableDataSource<VAT>(this.vat);
        this.datasource.paginator = this.paginator;
      });
  }

  ActivateVat(id: number){
    this.ecommerceService.activateVat(id).subscribe({
      next: ()=>{
        this.GetAllVat();
      }
    })
  }

  EditVat(id: number) {
    this.ecommerceService.Id = id;
  }

  RequestToDeleteVat(id: number) {
    this.ecommerceService.Id = id;
    
  }

  OpenModal() {
    const ref = this.dialog.open(AddVatComponent, {
      width: "50%",
      height: "auto",
    });
    ref.afterClosed().subscribe(() => {
      this.GetAllVat();
    });
  }

  OpenEditModal() {
    const ref = this.dialog.open(EditVatComponent, {
      width: "50%",
      height: "auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllVat();
    });
  }

  OpenDeleteModal() {
    const ref = this.dialog.open(DeleteVatComponent, {
      width: "30%",
      height: "Auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllVat();
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
