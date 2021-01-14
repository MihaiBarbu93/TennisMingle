import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { City } from '../_models/city';

@Injectable({
  providedIn: 'root',
})
export class CitiesService {
  city!: City;
  baseUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCities();
  }

  getCities() {
    return this.http.get<City[]>(this.baseUrl + 'cities');
  }

  getCity(cityId: number) {
    return this.http.get<City>(this.baseUrl + 'cities/' + cityId);
  }


  getCityName(cityId: number) {
    this.getCity(cityId).subscribe((city) => {
      this.city = city;
    });
  }
}
