import { City } from './../../_models/city';
import { TennisClubsService } from './../../_services/tennis-clubs.service';
import { Component, Input, OnInit } from '@angular/core';
import { TennisClub } from 'src/app/_models/tennisClub';
import { ActivatedRoute } from '@angular/router';
import { CitiesService } from 'src/app/_services/cities.service';

@Component({
  selector: 'app-tennis-club-list',
  templateUrl: './tennis-club-list.component.html',
  styleUrls: ['./tennis-club-list.component.css'],
})
export class TennisClubListComponent implements OnInit {
  tennisClubs: TennisClub[] = [];
  cityId!: number;
  constructor(
    private tennisClubService: TennisClubsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.cityId = +this.route.snapshot.params.cityId;
    console.log(this.cityId);
    this.loadTennisClubs(this.cityId);
  }

  loadTennisClubs(cityId: number) {
    return this.tennisClubService
      .getTennisClubs(cityId)
      .subscribe((tennisClubs) => {
        this.tennisClubs = tennisClubs;
      });
  }
}
