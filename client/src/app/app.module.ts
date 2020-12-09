import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { TennisClubListComponent } from './tennis-club/tennis-club-list/tennis-club-list.component';
import { TennisClubDetailComponent } from './tennis-club/tennis-club-detail/tennis-club-detail.component';
import { TennisClubCardComponent } from './tennis-club/tennis-club-card/tennis-club-card.component';

@NgModule({
  declarations: [AppComponent, NavComponent, HomeComponent, TennisClubListComponent, TennisClubDetailComponent, TennisClubCardComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
