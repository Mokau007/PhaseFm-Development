import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PhaseFmShopRoutingModule } from './phase-fm-shop-routing.module';
import { HomeComponent } from './Features/home/home.component';
import { AboutUsComponent } from './Features/about-us/about-us.component';
import { ProductsComponent } from './Features/merchandise-interaction/products/products.component';
import { BasketComponent } from './Features/merchandise-interaction/basket-management/basket/basket.component';
import { PayFastCheckoutComponent } from './Features/merchandise-interaction/basket-management/pay-fast-checkout/pay-fast-checkout.component';
import { EditDeliveryAddressComponent } from './Features/merchandise-interaction/basket-management/edit-delivery-address/edit-delivery-address.component';
import { LogInComponent } from './Features/user-management/log-in/log-in.component';
import { ForgotPassowrdComponent } from './Features/user-management/forgot-passowrd/forgot-passowrd.component';
import { RegisterComponent } from './Features/user-management/register/register.component';
import { EmailConfirmationComponent } from './Features/user-management/email-confirmation/email-confirmation.component';
import { ResetPasswordComponent } from './Features/user-management/reset-password/reset-password.component';
import { ViewAccountComponent } from './Features/user-management/view-account/view-account.component';
import { DeleteAccountComponent } from './Features/user-management/delete-account/delete-account.component';
import { OrdersPendingComponent } from './Features/order-management/orders-pending/orders-pending.component';
import { OrderHistoryComponent } from './Features/order-management/order-history/order-history.component';
import { OrdersCompletedComponent } from './Features/order-management/orders-completed/orders-completed.component';
import { OrderManagementTabsComponent } from './Features/order-management/order-management-tabs/order-management-tabs.component';
import { OrderDetailsComponent } from './Features/order-management/order-details/order-details.component';
import { NavbarComponent } from './Core/navbar/navbar.component';
import { FooterComponent } from './Core/footer/footer.component';
import { MaterialModule } from '../phase-fm-radio/Shared/AngularMaterial/material.module';


@NgModule({
  declarations: [
    HomeComponent,
    AboutUsComponent,
    ProductsComponent,
    BasketComponent,
    PayFastCheckoutComponent,
    EditDeliveryAddressComponent,
    LogInComponent,
    ForgotPassowrdComponent,
    RegisterComponent,
    EmailConfirmationComponent,
    ResetPasswordComponent,
    ViewAccountComponent,
    DeleteAccountComponent,
    OrdersPendingComponent,
    OrderHistoryComponent,
    OrdersCompletedComponent,
    OrderManagementTabsComponent,
    OrderDetailsComponent,
    NavbarComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    PhaseFmShopRoutingModule,
    MaterialModule
  ]
})
export class PhaseFmShopModule { }
