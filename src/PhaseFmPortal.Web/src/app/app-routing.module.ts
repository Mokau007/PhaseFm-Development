import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    loadChildren:()=> import('./admin-portal/admin-portal.module').then((m)=> m.AdminPortalModule) 
  },

  {
    path:'PhaseFmPortal',
    loadChildren:()=> import('./admin-portal-authentication/admin-portal-authentication.module').then((m)=> m.AdminPortalAuthenticationModule) 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
