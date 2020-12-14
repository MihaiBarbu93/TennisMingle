import { DataService } from './../../_services/data-service.service';
import { City } from './../../_models/city';
import { TennisClubsService } from './../../_services/tennis-clubs.service';
import { Component, Input, OnInit } from '@angular/core';
import { TennisClub } from 'src/app/_models/tennisClub';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tennis-club-list',
  templateUrl: './tennis-club-list.component.html',
  styleUrls: ['./tennis-club-list.component.css'],
})
export class TennisClubListComponent implements OnInit {
  tennisClubs: TennisClub[] = [];
  cityId!: number;
  facilitiesDynamic: string[] = [];
  facilities: string[] = [
    'PARKING',
    'TOILETS',
    'DRESSROOM',
    'SHOWERS',
    'STANDS',
    'NOCTURNE',
    'OUTDOOR_LAND',
    'BAR',
    'TERRASE',
    'WI_FI',
    'RESTAURANT',
  ];
  surfaces: string[] = [
    'ACRYLIC',
    'ARTIFICIAL_CLAY',
    'ARTIFICIAL_GRASS',
    'ASPHALT',
    'CARPET',
    'CLAY',
    'CONCRETE',
    'GRASS',
  ];
  constructor(
    private tennisClubService: TennisClubsService,
    private route: ActivatedRoute,
    private data: DataService,
    private router: Router
  ) {
    this.subscribeRouteChange();
  }

  ngOnInit(): void {
    this.cityId = +this.route.snapshot.params.cityId;

    this.loadTennisClubs(this.cityId);
  }

  loadTennisClubs(cityId: number) {
    return this.router.url.includes('courts')
      ? this.tennisClubService
          .getTennisClubsWithCourtsAvailable(cityId)
          .subscribe((tennisClubs) => {
            this.tennisClubs = tennisClubs;
          })
      : this.tennisClubService
          .getTennisClubs(cityId)
          .subscribe((tennisClubs) => {
            this.tennisClubs = tennisClubs;
          });
  }

  subscribeRouteChange() {
    this.route.params.subscribe((params = {}) => {
      this.loadTennisClubs(params.cityId);
      this.data.changeMessage(params.cityId);
    });
  }
}
