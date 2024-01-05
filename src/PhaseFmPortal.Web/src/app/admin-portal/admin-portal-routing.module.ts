import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PortalNavComponent } from './Core/portal-nav/portal-nav.component';
import { ProductManagementTabsComponent } from './Features/ecommerce-subsystem/product-management/product-management-tabs/product-management-tabs.component';
import { SuccessAlertComponent } from './Shared/Alerts/success-alert/success-alert.component';

const routes: Routes = [
  {
    path:'',
    component: PortalNavComponent,
    children:
    [

      {path:'product-management' , component: ProductManagementTabsComponent},
      
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminPortalRoutingModule { }
