import { HttpErrorResponse } from '@angular/common/http';
import { Component, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { ErrorAlertComponent } from 'src/app/admin-portal/Shared/Alerts/error-alert/error-alert.component';

@Component({
  selector: 'app-delete-vat',
  templateUrl: './delete-vat.component.html',
  styleUrls: ['./delete-vat.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DeleteVatComponent {

  errorMessage: string = '';
  showError!: boolean;

  constructor(private ecommerceService: EcommerceService,private ref:MatDialogRef<DeleteVatComponent>, private dialog:MatDialog)   {}

  DeleteVat(){
    this.ecommerceService.deleteVat(this.ecommerceService.Id).subscribe({
      next:()=> {
        this.ref.close();
        
      },
      error: (err: HttpErrorResponse) => {
        this.ref.close()
        this.errorMessage = err.error;
        this.showError = true;
        this.dialog.open(ErrorAlertComponent,{
          width:'30%',
          height:'Auto',
          data: this.errorMessage,

        })
      }
     
    })
  }

  CloseModal(){
    this.ref.close();
  }
}
