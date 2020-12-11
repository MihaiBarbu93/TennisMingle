import { DataService } from './../_services/data-service.service';
import { ActivatedRoute } from '@angular/router';
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
  cityName!: string;

  constructor(
    private citiesService: CitiesService,
    private data: DataService
  ) {}

  ngOnInit(): void {
    this.loadCities();
  }

  loadCities() {
    return this.citiesService.getCities().subscribe((cities) => {
      this.cities = cities;
      this.cityName = cities[0].name;
    });
  }

  isHiddenChange(): void {
    this.data.currentMessage.subscribe(
      (message) => (this.cityName = this.cities[+message - 1].name)
    );
  }
}
