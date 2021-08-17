import { Component, Input, OnInit } from '@angular/core';
import { IDesk } from 'src/app/shared/models/desk';

@Component({
  selector: 'app-desk-item',
  templateUrl: './desk-item.component.html',
  styleUrls: ['./desk-item.component.scss']
})
export class DeskItemComponent implements OnInit {
  @Input() desk: IDesk;

  constructor() { }

  ngOnInit(): void {
  }

}
