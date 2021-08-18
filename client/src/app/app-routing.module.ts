import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DeskDetailsComponent } from './shop/desk-details/desk-details.component';
import { ShopComponent } from './shop/shop.component';
import { ShopModule } from './shop/shop.module';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule)},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
