import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PortalNavComponent } from './Core/portal-nav/portal-nav.component';
import { ProductManagementTabsComponent } from './Features/ecommerce-subsystem/product-management/product-management-tabs/product-management-tabs.component';
import { SuccessAlertComponent } from './Shared/Alerts/success-alert/success-alert.component';
import { DiscountComponent } from './Features/ecommerce-subsystem/crud-discount/discount/discount.component';
import { VatComponent } from './Features/ecommerce-subsystem/crud-vat/vat/vat.component';
import { DeliveryComponent } from './Features/ecommerce-subsystem/crud-delivery/delivery/delivery.component';

const routes: Routes = [
  {
    path:'',
    component: PortalNavComponent,
    children:
    [
      {path:'product-management' , component: ProductManagementTabsComponent},
      {path:'discount' , component: DiscountComponent},
      {path:'vat' , component: VatComponent},
      {path:'delivery-fee' , component: DeliveryComponent},
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminPortalRoutingModule { }
