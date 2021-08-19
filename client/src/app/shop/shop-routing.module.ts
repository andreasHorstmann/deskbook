import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeskDetailsComponent } from './desk-details/desk-details.component';
import { ShopComponent } from './shop.component';

const routes: Routes = [
  {path: '', component: ShopComponent},
  {path: ':id', component: DeskDetailsComponent, data:{breadcrumb: {alias: 'deskDetails'}}},
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ShopRoutingModule { }
