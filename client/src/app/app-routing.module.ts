import { TennisClubListComponent } from './tennis-club/tennis-club-list/tennis-club-list.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TennisClubDetailComponent } from './tennis-club/tennis-club-detail/tennis-club-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cities/:cityId/tennis-clubs', component: TennisClubListComponent },
  {
    path: 'cities/:cityId/tennis-clubs-withcourts',
    component: TennisClubListComponent,
  },
  { path: 'tennis-clubs/:id', component: TennisClubDetailComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
