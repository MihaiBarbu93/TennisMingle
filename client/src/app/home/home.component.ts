import { Router } from '@angular/router';
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
import { FormControl } from '@angular/forms';
import { FormGroup, FormBuilder } from '@angular/forms';

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
  public ngxControl = new FormControl();
  citiesSelect: string[] = [];
  findCourtForm!: FormGroup;
  citySelected: number = 1;

  constructor(
    private citiesService: CitiesService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadCities();
    this.initializeForm();
  }
  initializeForm(): void {
    this.findCourtForm = this.formBuilder.group({
      selectCity: '',
    });
  }

  onSubmit(): void {
    this.router.navigateByUrl('cities/' + this.citySelected + '/tennis-clubs');
  }

  selectCity(event: { target: { value: any } }): void {
    this.findCourtForm.patchValue({
      selectCity: event.target.value,
    });
    console.log(this.cities);
    console.log(this.cities.findIndex((city) => event.target.value));
    this.citySelected =
      this.cities.findIndex((city) => city.name == event.target.value) + 1;
    console.log(this.citySelected);
  }

  loadCities() {
    return this.citiesService.getCities().subscribe((cities) => {
      this.cities = cities;
      this.getCitiesNames();
    });
  }

  getCitiesNames() {
    this.cities.forEach((city) => {
      console.log(city);
      this.citiesSelect.push(city.name);
    });
  }
}
