import { Component, OnInit } from '@angular/core';
import { ShowReel } from 'src/app/models/show-reel';
import { ShowReelService } from 'src/app/services/show-reel.service';

@Component({
  selector: 'app-show-reel-list',
  templateUrl: './show-reel-list.component.html',
  styleUrls: ['./show-reel-list.component.css']
})
export class ShowReelListComponent implements OnInit {


  constructor(
    private showReelService: ShowReelService) { }

  showReels?: ShowReel[];
  videoDefinitions?: {key: string, value: number}[];
  videoStandards?: {key: string, value: number}[];

  ngOnInit(): void {
    this.videoDefinitions = this.showReelService.getVideoDefinitions();
    this.videoStandards = this.showReelService.getVideoStandards();
    this.showReelService.get().subscribe(response => {
      this.showReels = response;
    });
  }

}
