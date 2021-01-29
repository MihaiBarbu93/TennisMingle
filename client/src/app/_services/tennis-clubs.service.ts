import { FacilityType } from './../_models/enums/facilityType';
import { TennisClub } from './../_models/tennisClub';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TennisClubsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getTennisClubs(cityId: number) {
    return this.http.get<TennisClub[]>(
      this.baseUrl + 'cities/' + cityId + '/tennisclubs'
    );
  }

  getTennisClubById(cityId: number, tennisClubId: number) {
    return this.http.get<TennisClub>(
      this.baseUrl + 'cities/' + cityId + '/tennisclubs/' + tennisClubId
    );
  }

  getTennisClubByUserId(userId: number) {
    return this.http.get<TennisClub>(
      this.baseUrl + 'cities/1/tennisclubs/' + userId
    );
  }

  getTennisClubsWithCourtsAvailable(cityId: number) {
    return this.http.get<TennisClub[]>(
      this.baseUrl + 'cities/' + cityId + '/tennisclubs/withcourtsavailable'
    );
  }

  getFacilitiesForTennisClubsPerCity(cityId: number) {
    let facilities = this.http.get<string[]>(
      this.baseUrl + 'cities/' + cityId + '/tennisclubs/allfacilities'
    );
    return facilities;
  }

  getSurfacesForTennisClubsPerCity(cityId: number) {
    let surfaces = this.http.get<string[]>(
      this.baseUrl + 'cities/' + cityId + '/allsurfaces'
    );
    return surfaces;
  }
}
