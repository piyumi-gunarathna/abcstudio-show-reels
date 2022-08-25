import { Component, Input, OnInit } from '@angular/core';
import { ShowReel } from 'src/app/models/show-reel';

@Component({
  selector: 'app-show-reel-list-item',
  templateUrl: './show-reel-list-item.component.html',
  styleUrls: ['./show-reel-list-item.component.css']
})
export class ShowReelListItemComponent implements OnInit {
  @Input() showReel?:ShowReel;
  @Input() videoDefinitions?: {key: string, value: number}[];
  @Input() videoStandards?: {key: string, value: number}[];

  videoDefinition: string = '';
  videoStandard: string = '';
  totalTime: string = '';

  constructor() {
    
  }

  ngOnInit(): void {
    this.videoDefinition = this.videoDefinitions?.filter(vd => this.showReel?.videoDefinition && 
      vd.value == this.showReel?.videoDefinition)[0].key ?? '';

    this.videoStandard = this.videoStandards?.filter(vs => this.showReel?.videoStandard && 
      vs.value == this.showReel?.videoStandard)[0].key ?? '';
    
    this.totalTime = this.showReel?.videoClips[this.showReel?.videoClips.length - 1].endTimeCode.ToString ?? '';
  }

}
