import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoClipComponent } from './video-clip.component';

describe('VideoClipComponent', () => {
  let component: VideoClipComponent;
  let fixture: ComponentFixture<VideoClipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VideoClipComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VideoClipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
