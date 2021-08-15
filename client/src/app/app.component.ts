import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IDesk } from './models/desk';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'BookDesk';
  desks: IDesk[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/desks?pageSize=5').subscribe((response: IPagination) => {
      this.desks = response.data;
    }, error => {
      console.log(error);
    })
  }
}
