import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PhaseFmNavbarComponent } from './Core/phase-fm-navbar/phase-fm-navbar.component';
import { HomeComponent } from './Features/home/home.component';
import { AboutUsComponent } from './Features/about-us/about-us.component';

const routes: Routes = [
  {
    path:'',
    component: PhaseFmNavbarComponent,
    children:[

      { path:'', component: HomeComponent},
      { path:'home', component: HomeComponent, title:'Phase-Fm-Home'},
      { path:'about-us', component: AboutUsComponent},
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhaseFmRadioRoutingModule { }
