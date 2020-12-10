import { TennisClubsService } from './../../_services/tennis-clubs.service';
import { Component, OnInit } from '@angular/core';
import { TennisClub } from 'src/app/_models/tennisClub';

@Component({
  selector: 'app-tennis-club-list',
  templateUrl: './tennis-club-list.component.html',
  styleUrls: ['./tennis-club-list.component.css'],
})
export class TennisClubListComponent implements OnInit {
  tennisClubs: TennisClub[] = [];
  constructor(private tennisClubService: TennisClubsService) {}

  ngOnInit(): void {
    this.loadTennisClubs(1);
  }

  loadTennisClubs(cityId: number) {
    return this.tennisClubService
      .getTennisClubs(cityId)
      .subscribe((tennisClubs) => {
        this.tennisClubs = tennisClubs;
      });
  }
}
