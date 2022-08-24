import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowReelListComponent } from './components/show-reel-list/show-reel-list.component';
import { ShowReelComponent } from './components/show-reel/show-reel.component';


const routes: Routes = [
  { path: 'new-show-reel', component: ShowReelComponent},
  { path: 'edit-show-reel', component: ShowReelComponent},
  { path: 'show-reel-list', component: ShowReelListComponent},
  { path: '**', component: ShowReelListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
