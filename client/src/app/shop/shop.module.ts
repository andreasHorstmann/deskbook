import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { DeskItemComponent } from './desk-item/desk-item.component';
import { SharedModule } from '../shared/shared.module';
import { DeskDetailsComponent } from './desk-details/desk-details.component';
import { ShopRoutingModule } from './shop-routing.module';



@NgModule({
  declarations: [
    ShopComponent,
    DeskItemComponent,
    DeskDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ShopRoutingModule
  ],
  exports: []
})
export class ShopModule { }
