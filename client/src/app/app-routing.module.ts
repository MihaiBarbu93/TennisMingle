import { TennisClubListComponent } from './tennis-club/tennis-club-list/tennis-club-list.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TennisClubDetailComponent } from './tennis-club/tennis-club-detail/tennis-club-detail.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cities/:cityId/tennis-clubs', component: TennisClubListComponent },
  {
    path: 'cities/:cityId/tennis-clubs-withcourts',
    component: TennisClubListComponent,
  },
  { path: 'cities/:cityId/tennis-clubs/:id', component: TennisClubDetailComponent },
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
