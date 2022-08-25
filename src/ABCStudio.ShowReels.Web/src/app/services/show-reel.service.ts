import { KeyValue } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ShowReel } from '../models/show-reel';
import { TimeCode } from '../models/time-code';
import { VideoClip } from '../models/video-clip';

@Injectable({
  providedIn: 'root'
})
export class ShowReelService {

  private showReelApiUrl: string = "http://localhost:7106/api/";
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };
  
  constructor(private httpClient: HttpClient) { 
  }

  getVideoDefinitions(): {key: string, value: number}[] {
    return [{ key: 'SD', value: 1 }, { key: 'HD', value: 2 }];
  }

  getVideoStandards(): {key: string, value: number}[] {
    return [{ key: 'PAL', value: 25 }, { key: 'NTSC', value: 30 }];
  }
  
  get(): Observable<ShowReel[]> {
    return this.httpClient.get<ShowReel[]>(`${this.showReelApiUrl}showreel`)
      .pipe(map(showReels => showReels.map(s => { 
        var videoClips = s.videoClips.map(v => {
          var startTimeCode = new TimeCode(
            v.startTimeCode.hours, 
            v.startTimeCode.minutes, 
            v.startTimeCode.seconds, 
            v.startTimeCode.frames, 
            v.startTimeCode.framesPerSecond
          );
          var endTimeCode = new TimeCode(
            v.endTimeCode.hours, 
            v.endTimeCode.minutes, 
            v.endTimeCode.seconds, 
            v.endTimeCode.frames, 
            v.endTimeCode.framesPerSecond
          );

          return new VideoClip(
            v.name, 
            v.description, 
            v.definition,
            v.standard,
            startTimeCode,
            endTimeCode
            );
        });
        return new ShowReel(
          s.name, 
          s.description, 
          s.videoDefinition, 
          s.videoStandard, 
          videoClips);
      })));
  }

  save(showReel: ShowReel): Observable<object> {
    return this.httpClient.post(`${this.showReelApiUrl}showreel`,showReel, this.httpOptions);
  }
}
