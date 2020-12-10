import { CitiesService } from './../_services/cities.service';
import { Component, OnInit } from '@angular/core';
import { City } from '../_models/city';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  registerMode = false;
  cities: City[] = [];
  model: any = {};
  faSearch = faSearch;
  constructor(private citiesService: CitiesService,public accountService: AccountService, 
    private router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.loadCities();
  }

  loadCities() {
    return this.citiesService.getCities().subscribe((cities) => {
      this.cities = cities;
    });
  }
  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/');
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}
