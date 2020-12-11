import { CitiesService } from './../_services/cities.service';
import { Component, OnInit, TemplateRef  } from '@angular/core';
import { City } from '../_models/city';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  cities: City[] = [];
  
  modalRef!: BsModalRef;
  faSearch = faSearch;
  config = {
    keyboard: true
  };

  constructor(private citiesService: CitiesService,public accountService: AccountService, 
    private router: Router, private toastr: ToastrService, private modalService: BsModalService) {}

  ngOnInit(): void {
    this.loadCities();
  }

  loadCities() {
    return this.citiesService.getCities().subscribe((cities) => {
      this.cities = cities;
    });
  }
  

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  openModal(template: TemplateRef<any>) {
    console.log("open modal");
    this.modalRef = this.modalService.show(template, this.config);
  }

 


}
