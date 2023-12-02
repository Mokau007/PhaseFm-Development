import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './Core/navbar/navbar.component';
import { HomeComponent } from './Features/home/home.component';
import { AboutUsComponent } from './Features/about-us/about-us.component';
import { ProductsComponent } from './Features/merchandise-interaction/products/products.component';

const routes: Routes = [
  {path:'',
  component: NavbarComponent,
  children:[

    { path:'', component: HomeComponent},
    { path:'home', component: HomeComponent, title:'Phase-Fm-Home'},
    { path:'about-us', component: AboutUsComponent},
    { path:'product', component: ProductsComponent},
    
  ],
},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhaseFmShopRoutingModule { }
