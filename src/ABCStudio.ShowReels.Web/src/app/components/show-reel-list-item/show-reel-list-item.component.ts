import { Component, Input, OnInit } from '@angular/core';
import { ShowReel } from 'src/app/models/show-reel';

@Component({
  selector: 'app-show-reel-list-item',
  templateUrl: './show-reel-list-item.component.html',
  styleUrls: ['./show-reel-list-item.component.css']
})
export class ShowReelListItemComponent implements OnInit {
  @Input() showReel?:ShowReel;

  constructor() { }

  ngOnInit(): void {
  }

}
