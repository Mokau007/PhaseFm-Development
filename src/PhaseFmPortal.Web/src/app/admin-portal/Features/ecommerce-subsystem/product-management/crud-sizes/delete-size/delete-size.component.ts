import { HttpErrorResponse } from '@angular/common/http';
import { Component, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { EcommerceService } from 'src/app/admin-portal/Core/services/ecommerce-service/ecommerce.service';
import { ErrorAlertComponent } from 'src/app/admin-portal/Shared/Alerts/error-alert/error-alert.component';

@Component({
  selector: 'app-delete-size',
  templateUrl: './delete-size.component.html',
  styleUrls: ['./delete-size.component.scss'],
  encapsulation: ViewEncapsulation.None,

})
export class DeleteSizeComponent {

  errorMessage: string = '';
  showError!: boolean;

  constructor(private ecommerceService: EcommerceService,private ref:MatDialogRef<DeleteSizeComponent>, private dialog:MatDialog)   {}

  DeleteSize(){
    this.ecommerceService.deleteSize(this.ecommerceService.Id).subscribe({
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
