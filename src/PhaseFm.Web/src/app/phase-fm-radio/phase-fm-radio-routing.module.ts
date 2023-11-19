import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PhaseFmNavbarComponent } from './Core/phase-fm-navbar/phase-fm-navbar.component';
import { HomeComponent } from './Features/home/home.component';

const routes: Routes = [
  {
    path:'',
    component: PhaseFmNavbarComponent,
    children:[

      { path:'', component: HomeComponent}
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhaseFmRadioRoutingModule { }
