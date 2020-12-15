import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from './../../_services/data-service.service';
import { City } from './../../_models/city';
import { TennisClubsService } from './../../_services/tennis-clubs.service';
import { Component, Input, OnInit } from '@angular/core';
import { TennisClub } from 'src/app/_models/tennisClub';
import { ActivatedRoute, Router } from '@angular/router';
import { faThemeisle } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-tennis-club-list',
  templateUrl: './tennis-club-list.component.html',
  styleUrls: ['./tennis-club-list.component.css'],
})
export class TennisClubListComponent implements OnInit {
  tennisClubs: TennisClub[] = [];
  cityId!: number;
  facilities: string[] = [];
  surfaces: string[] = [];
  reactiveForm!: FormGroup;
  selectedFacilitiesValues!: string[];
  selectedFacilitiesError: boolean = true;

  constructor(
    private tennisClubService: TennisClubsService,
    private route: ActivatedRoute,
    private data: DataService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.subscribeRouteChange();
  }

  ngOnInit(): void {
    this.cityId = +this.route.snapshot.params.cityId;
    this.loadAllData(this.cityId);
  }

  initForm() {
    this.reactiveForm = this.formBuilder.group({
      facilitiesCheckBoxes: this.addFacilitiesControl(),
    });
  }

  addFacilitiesControl() {
    const arr = this.facilities.map((facility) => {
      return this.formBuilder.control(false);
    });

    console.log(arr);

    return this.formBuilder.array(arr);
  }

  get facilitiesArray() {
    return <FormArray>this.reactiveForm.get('facilitiesCheckBoxes');
  }

  getSelectedFacilitiesValue() {
    this.selectedFacilitiesValues = [];
    this.facilitiesArray.controls.forEach((control, i) => {
      if (control.value) {
        this.selectedFacilitiesValues.push(this.facilities[i]);
      }
    });
    this.selectedFacilitiesError =
      this.selectedFacilitiesValues.length > 0 ? false : true;
  }

  checkFacilitiesControlTouched() {
    let flg = false;
    this.facilitiesArray.controls.forEach((control) => {
      if (control.touched) {
        flg = true;
      }
    });
    return flg;
  }

  submitHandler() {
    console.log('sugeoooo');
    const newQuery = this.selectedFacilitiesValues;
    if (this.reactiveForm.valid && !this.selectedFacilitiesError) {
      console.log('sugeoooo');
      console.log(this.reactiveForm.value, newQuery);
    }
  }

  loadAllData(cityId: number) {
    this.loadTennisClubs(cityId);
    this.loadFacilities(cityId);
    this.loadSurfaces(cityId);
  }

  loadTennisClubs(cityId: number) {
    return this.router.url.includes('courts')
      ? this.tennisClubService
          .getTennisClubsWithCourtsAvailable(cityId)
          .subscribe((tennisClubs) => {
            this.tennisClubs = tennisClubs;
          })
      : this.tennisClubService
          .getTennisClubs(cityId)
          .subscribe((tennisClubs) => {
            this.tennisClubs = tennisClubs;
          });
  }

  loadFacilities(cityId: number) {
    return this.tennisClubService
      .getFacilitiesForTennisClubsPerCity(cityId)
      .subscribe((facilities) => {
        this.facilities = facilities;
        this.reactiveForm = this.formBuilder.group({
          facilitiesCheckBoxes: this.addFacilitiesControl(),
        });
        this.initForm();
      });
  }

  loadSurfaces(cityId: number) {
    return this.tennisClubService
      .getSurfacesForTennisClubsPerCity(cityId)
      .subscribe((surfaces) => {
        this.surfaces = surfaces;
      });
  }

  subscribeRouteChange() {
    this.route.params.subscribe((params = {}) => {
      this.loadAllData(params.cityId);
      this.data.changeMessage(params.cityId);
    });
  }
}
