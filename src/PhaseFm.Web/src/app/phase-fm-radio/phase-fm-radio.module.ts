import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PhaseFmRadioRoutingModule } from './phase-fm-radio-routing.module';
import { HomeComponent } from './Features/home/home.component';
import { AboutUsComponent } from './Features/about-us/about-us.component';
import { RadioShowsComponent } from './Features/radio-shows/radio-shows.component';
import { NewsComponent } from './Features/news/news.component';
import { EventsComponent } from './Features/events/events.component';
import { GalleryComponent } from './Features/media/gallery/gallery.component';
import { MediaaContentComponent } from './Features/media/mediaa-content/mediaa-content.component';
import { ContactUsComponent } from './Features/user-submissions/contact-us/contact-us.component';
import { SubmitMusicComponent } from './Features/user-submissions/submit-music/submit-music.component';
import { MusicRequestComponent } from './Features/user-submissions/music-request/music-request.component';
import { PhaseFmNavbarComponent } from './Core/phase-fm-navbar/phase-fm-navbar.component';
import { PhaseFmFooterComponent } from './Core/phase-fm-footer/phase-fm-footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    HomeComponent,
    AboutUsComponent,
    RadioShowsComponent,
    NewsComponent,
    EventsComponent,
    GalleryComponent,
    MediaaContentComponent,
    ContactUsComponent,
    SubmitMusicComponent,
    MusicRequestComponent,
    PhaseFmNavbarComponent,
    PhaseFmFooterComponent
  ],
  imports: [
    CommonModule,
    PhaseFmRadioRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    
  ]
})
export class PhaseFmRadioModule { }
