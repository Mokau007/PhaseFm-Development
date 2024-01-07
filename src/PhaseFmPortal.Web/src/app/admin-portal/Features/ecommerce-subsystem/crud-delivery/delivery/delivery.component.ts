import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { DeliveryFee } from 'src/app/admin-portal/Shared/Models/Ecommerce/delivery-fee';
import { AddDeliveryComponent } from '../add-delivery/add-delivery.component';
import { EditDeliveryComponent } from '../edit-delivery/edit-delivery.component';
import { DeleteDeliveryComponent } from '../delete-delivery/delete-delivery.component';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.scss'],
})
export class DeliveryComponent implements OnInit {

  deliveryFee: DeliveryFee[] = [];

  datasource: any;
  displayedColumns: string[] = ["Price", "Activate", "Edit", "Delete"];
  @ViewChild(MatPaginator) paginator!: MatPaginator; 

  @ViewChild(MatSort) sort!: MatSort; 
  constructor(
    private ecommerceService: EcommerceService,
    private dialog: MatDialog,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  ngOnInit(): void {
    this.GetAllDeliveryFee();
  }

  GetAllDeliveryFee() {
    this.ecommerceService
      .getAllDelivery()
      .subscribe((result: DeliveryFee[]) => {
        this.deliveryFee = result;
        this.datasource = new MatTableDataSource<DeliveryFee>(this.deliveryFee);
        this.datasource.paginator = this.paginator;
      });
  }

  ActivateDeliveryFee(id: number){
    this.ecommerceService.activateDelivery(id).subscribe({
      next: ()=>{
        this.GetAllDeliveryFee();
      }
    })
  }

  EditDeliveryFee(id: number) {
    this.ecommerceService.Id = id;
  }

  RequestToDeleteDeliveryFee(id: number) {
    this.ecommerceService.Id = id;
    
  }

  OpenModal() {
    const ref = this.dialog.open(AddDeliveryComponent, {
      width: "50%",
      height: "auto",
    });
    ref.afterClosed().subscribe(() => {
      this.GetAllDeliveryFee();
    });
  }

  OpenEditModal() {
    const ref = this.dialog.open(EditDeliveryComponent, {
      width: "50%",
      height: "auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllDeliveryFee();
    });
  }

  OpenDeleteModal() {
    const ref = this.dialog.open(DeleteDeliveryComponent, {
      width: "30%",
      height: "Auto",
    });

    ref.afterClosed().subscribe(() => {
      this.GetAllDeliveryFee();
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
