
import { Component, OnInit } from '@angular/core';
import { ShowReelService } from '../../services/show-reel.service';
import { FormBuilder, FormArray, Validators } from '@angular/forms';
import { VideoClip } from '../../models/video-clip';
import { TimeCode } from '../../models/time-code';
import { ShowReel } from '../../models/show-reel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-show-reel',
  templateUrl: './show-reel.component.html',
  styleUrls: ['./show-reel.component.css']
})
export class ShowReelComponent implements OnInit {

  frameRates = new Map<number, number>();
  totalTime: TimeCode;

  videoDefinitions?: any[];
  videoStandards?: any[];

  showReelForm = this.formBuilder.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]],
    videoDefinition: ['', [Validators.required, Validators.min(1), Validators.max(2)]],
    videoStandard: ['', [Validators.required, Validators.min(1), Validators.max(2)]],
    videoClips: this.formBuilder.array([
      this.formBuilder.group({
        videoClipName: [''],
        videoClipDescription: [''],
        videoStartHH: ['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        videoStartMM: ['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        videoStartSS: ['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        videoStartFF: ['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        videoEndHH: ['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        videoEndMM: ['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        videoEndSS: ['00', [Validators.required, Validators.min(0), Validators.max(59)]],
        videoEndFF: ['00', [Validators.required, Validators.min(0), Validators.max(59)]]
      })
    ])
  });


  constructor(
    private showReelService: ShowReelService,
    private formBuilder: FormBuilder,
    private router: Router) {
    this.frameRates.set(1, 25);
    this.frameRates.set(2, 30);
    this.totalTime = new TimeCode(0, 0, 0, 0, 25);
  }

  ngOnInit(): void {
    var self = this;
    this.videoClips.disable();

    this.videoDefinitions = this.showReelService.getVideoDefinitions();
    this.videoStandards = this.showReelService.getVideoStandards();

    this.showReelForm.get('videoStandard')?.valueChanges.subscribe(v => {
      console.log(this.frameRates.get(parseInt(v ?? '')));
      if (parseInt(v ?? '') > 0) {
        this.totalTime = new TimeCode(0, 0, 0, 0, this.frameRates.get(parseInt(v ?? '')) ?? 0);
        self.videoClips.enable();
      }
    });

    this.videoClips.valueChanges.subscribe(v => {
      var timeInfo = v as VideoClipTimeCodes[];
      var lastTimeInfo = timeInfo[timeInfo.length - 1];

      if (this.videoClips.enabled) {
        var timeCode = new TimeCode(
          parseInt(lastTimeInfo.videoEndHH ?? ''),
          parseInt(lastTimeInfo.videoEndMM ?? ''),
          parseInt(lastTimeInfo.videoEndSS ?? ''),
          parseInt(lastTimeInfo.videoEndFF ?? ''),
          this.totalTime.framesPerSecond
        );

        this.totalTime = timeCode;
      }
    });
  }

  public get videoClips() {
    return this.showReelForm.get('videoClips') as FormArray;
  }

  AddVideoClip() {
    var startTimeCode = this.totalTime.AddTimeCodes(new TimeCode(0, 0, 0, 1, this.totalTime.framesPerSecond));
    var endTimeCode = this.totalTime.AddTimeCodes(new TimeCode(0, 0, 0, 2, this.totalTime.framesPerSecond));
    this.videoClips.push(this.formBuilder.group({
      videoClipName: [''],
      videoClipDescription: [''],
      videoClipDefinition: [''],
      videoClipStandard: [''],
      videoStartHH: [startTimeCode.hours],
      videoStartMM: [startTimeCode.minutes],
      videoStartSS: [startTimeCode.seconds],
      videoStartFF: [startTimeCode.frames],
      videoEndHH: [endTimeCode.hours],
      videoEndMM: [endTimeCode.minutes],
      videoEndSS: [endTimeCode.seconds],
      videoEndFF: [endTimeCode.frames]
    }));

    this.totalTime = endTimeCode;
  }

  removeClip(i: number) {
    if (this.videoClips.length > 1) {
      this.videoClips.removeAt(i);
    }
  }

  onSubmit() {
    try {
      let clips = this.showReelForm.value.videoClips?.map(v => {

        console.log(this.showReelForm.value.videoStandard);
        var startTimeCode = new TimeCode(
          parseInt(v.videoStartHH ?? ''),
          parseInt(v.videoStartMM ?? ''),
          parseInt(v.videoStartSS ?? ''),
          parseInt(v.videoStartFF ?? ''),
          this.frameRates.get(parseInt(this.showReelForm.value.videoStandard ?? '')) ?? 0
        );
        var endTimeCode = new TimeCode(
          parseInt(v.videoEndHH ?? ''),
          parseInt(v.videoEndMM ?? ''),
          parseInt(v.videoEndSS ?? ''),
          parseInt(v.videoEndFF ?? ''),
          this.frameRates.get(parseInt(this.showReelForm.value.videoStandard ?? '')) ?? 0
        );

        return new VideoClip(
          v.videoClipName ?? '',
          v.videoClipDescription ?? '',
          parseInt(this.showReelForm.value.videoDefinition ?? ''),
          parseInt(this.showReelForm.value.videoStandard ?? ''),
          startTimeCode,
          endTimeCode);
      });

      var showReel = new ShowReel(
        this.showReelForm.value.name ?? '',
        this.showReelForm.value.description ?? '',
        parseInt(this.showReelForm.value.videoDefinition ?? ''),
        parseInt(this.showReelForm.value.videoStandard ?? ''),
        clips ?? []
      );
      console.log(showReel);
      this.showReelService.save(showReel).subscribe(response => {
        console.log(response);
        this.router.navigate(['show-reel-list']);
      });
    } catch (error: any) {
      alert(error);
    }
  }

  get isVideoStandardSelected(): boolean {
    if (this.showReelForm.value.videoStandard) {
      return parseInt(this.showReelForm.value.videoStandard) > 0;
    }
    return false;
  }

}

interface VideoClipTimeCodes {
  videoStartHH: string;
  videoStartMM: string;
  videoStartSS: string;
  videoStartFF: string;
  videoEndHH: string;
  videoEndMM: string;
  videoEndSS: string;
  videoEndFF: string;
}
