import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    loadChildren:()=> import('./phase-fm-radio/phase-fm-radio.module').then((m)=> m.PhaseFmRadioModule) 
  },

  {
    path:'Merchandise',
    loadChildren:()=> import('./phase-fm-shop/phase-fm-shop.module').then((m)=> m.PhaseFmShopModule) 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
