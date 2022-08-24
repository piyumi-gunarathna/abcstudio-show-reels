import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowReelListComponent } from './components/show-reel-list/show-reel-list.component';
import { ShowReelComponent } from './components/show-reel/show-reel.component';
import { ShowReelListItemComponent } from './components/show-reel-list-item/show-reel-list-item.component';
import { TimeCodeComponent } from './components/time-code/time-code.component';
import { VideoClipComponent } from './components/video-clip/video-clip.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ShowReelListComponent,
    ShowReelComponent,
    ShowReelListItemComponent,
    TimeCodeComponent,
    VideoClipComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
