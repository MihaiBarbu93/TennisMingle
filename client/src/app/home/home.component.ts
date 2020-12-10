import { CitiesService } from './../_services/cities.service';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { City } from '../_models/city';
import {
  faSearch,
  faCalendar,
  faRunning,
} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  baseUrl = environment.apiUrl;
  cities: City[] = [];
  faSearch = faSearch;
  faCalendar = faCalendar;
  faRunning = faRunning;

  constructor(private citiesService: CitiesService) {}

  ngOnInit(): void {
    this.loadCities();
  }

  loadCities() {
    return this.citiesService.getCities().subscribe((cities) => {
      this.cities = cities;
    });
  }
}
