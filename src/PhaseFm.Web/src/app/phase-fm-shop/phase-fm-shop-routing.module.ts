import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './Core/navbar/navbar.component';
import { HomeComponent } from './Features/home/home.component';
import { AboutUsComponent } from './Features/about-us/about-us.component';
import { ProductsComponent } from './Features/merchandise-interaction/products/products.component';
import { OrderManagementTabsComponent } from './Features/order-management/order-management-tabs/order-management-tabs.component';

const routes: Routes = [
  {path:'',
  component: NavbarComponent,
  children:[

    { path:'', component: HomeComponent},
    { path:'shop/home', component: HomeComponent, title:'Phase-Fm-Home'},
    { path:'shop/about-us', component: AboutUsComponent},
    { path:'shop/products', component: ProductsComponent},
    { path:'account-management', component: OrderManagementTabsComponent},
    
  ],
},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhaseFmShopRoutingModule { }
