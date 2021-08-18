import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDesk } from 'src/app/shared/models/desk';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-desk-details',
  templateUrl: './desk-details.component.html',
  styleUrls: ['./desk-details.component.scss']
})
export class DeskDetailsComponent implements OnInit {
  desk: IDesk;

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadDesk();
  }

  loadDesk() {
    this.shopService.getDesk(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(desk => {
      this.desk = desk;
    }, error => {
      console.log(error);
    })
  }

}
