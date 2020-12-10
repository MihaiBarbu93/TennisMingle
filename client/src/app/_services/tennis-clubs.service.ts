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

  getTennisClub(userId: number) {
    return this.http.get<TennisClub>(
      this.baseUrl + 'cities/1/tennisclubs/' + userId
    );
  }
}
