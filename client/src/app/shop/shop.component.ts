import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IDesk } from '../shared/models/desk';
import { IRoom } from '../shared/models/room';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  desks: IDesk[];
  rooms: IRoom[];
  shopParams = new ShopParams();
  totalCount: number;
  // sortOptions = [
  //   {name: 'Alphabetical', value: 'name'},
  // ]

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getDesks();
    this.getRooms();
  }

  getDesks() {
    this.shopService.getDesks(this.shopParams).subscribe(response => {
      this.desks = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    })
  }

  getRooms() {
    this.shopService.getRooms().subscribe(response => {
      this.rooms = [{id: 0, name: 'All', }, ...response]
     }, error => {
      console.log(error);
    })
  }

  onRoomSelected(roomId: number) {
    this.shopParams.roomId = roomId;
    this.shopParams.pageNumber = 1;
    this.getDesks();
  }

  // onSortSelected(sort: string) {
  //   this.shopParams.sort = sort;
  //   this.getDesks();
  // }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getDesks();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getDesks();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getDesks();
  }

}
