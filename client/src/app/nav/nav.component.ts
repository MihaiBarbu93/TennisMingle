import { DataService } from './../_services/data-service.service';
import { ActivatedRoute } from '@angular/router';
import { CitiesService } from './../_services/cities.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { City } from '../_models/city';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  cities: City[] = [];
  user: User;
  modalRef!: BsModalRef;
  faSearch = faSearch;
  config = {
    keyboard: true,
  };

  constructor(
    private citiesService: CitiesService,
    public accountService: AccountService,
    private router: Router,
    private modalService: BsModalService,
    private data: DataService
  ) {}
  selectedCity!: City;
  cityName!: string;
  loggedIn: boolean;

  ngOnInit(): void {
    this.getCurrentUser();
    this.loadCities();
  }

  loadCities() {
    return this.citiesService.getCities().subscribe((cities) => {
      this.cities = cities;
      this.cityName = cities[0].name;
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  openModal(template: TemplateRef<any>) {
    console.log('open modal');
    this.modalRef = this.modalService.show(template, this.config);
  }

  isHiddenChange(): void {
    this.data.currentMessage.subscribe(
      (message) => (this.cityName = this.cities[+message - 1].name)
    );
  }

  getCurrentUser() {
    this.accountService.currentUser$.subscribe(
      (user) => {
        this.loggedIn = !user;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
