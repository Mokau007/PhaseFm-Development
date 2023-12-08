import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminPortalAuthenticationRoutingModule } from './admin-portal-authentication-routing.module';
import { SignInComponent } from './Features/sign-in/sign-in.component';
import { ForgotPasswordComponent } from './Features/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './Features/reset-password/reset-password.component';


@NgModule({
  declarations: [
    SignInComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent
  ],
  imports: [
    CommonModule,
    AdminPortalAuthenticationRoutingModule
  ]
})
export class AdminPortalAuthenticationModule { }
