import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { IRoom } from '../shared/models/room';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  
  constructor(private http: HttpClient) { }

  getDesks(shopParams: ShopParams)
  {
    let params = new HttpParams();

    if (shopParams.roomId !== 0) {
      params = params.append('roomId', shopParams.roomId.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    // params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'desks', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      )
  }

  getRooms()
  {
    return this.http.get<IRoom[]>(this.baseUrl + 'desks/rooms');
  }
}
