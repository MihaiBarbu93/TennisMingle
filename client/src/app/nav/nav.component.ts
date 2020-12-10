import { CitiesService } from './../_services/cities.service';
import { Component, OnInit } from '@angular/core';
import { City } from '../_models/city';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  cities: City[] = [];
  faSearch = faSearch;
  selectedCity!: City;

  constructor(private citiesService: CitiesService) {}

  ngOnInit(): void {
    this.loadCities();
  }

  loadCities() {
    return this.citiesService.getCities().subscribe((cities) => {
      this.cities = cities;
      this.selectedCity = cities[0];
    });
  }
}
