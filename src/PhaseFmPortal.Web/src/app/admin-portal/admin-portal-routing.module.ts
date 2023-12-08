import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PortalNavComponent } from './Core/portal-nav/portal-nav.component';

const routes: Routes = [
  {
    path:'',
    component: PortalNavComponent,
    children:[

      
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminPortalRoutingModule { }
