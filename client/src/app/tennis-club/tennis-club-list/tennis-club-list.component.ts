import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from './../../_services/data-service.service';
import { City } from './../../_models/city';
import { TennisClubsService } from './../../_services/tennis-clubs.service';
import { Component, Input, OnInit } from '@angular/core';
import { TennisClub } from 'src/app/_models/tennisClub';
import { ActivatedRoute, Router } from '@angular/router';
import { ThisReceiver } from '@angular/compiler';
import { ConsoleReporter } from 'jasmine';

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
  selectedSurfacesValues!: string[];
  selectedSurfacesError: boolean = true;

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
      facilitiesCheckBoxes: this.addFormControl(this.facilities),
      surfacesCheckBoxes: this.addFormControl(this.surfaces),
    });
  }

  addFormControl(dataArray: string[]) {
    const arr = dataArray.map((data) => {
      return this.formBuilder.control(false);
    });
    return this.formBuilder.array(arr);
  }

  get facilitiesArray() {
    return <FormArray>this.reactiveForm.get('facilitiesCheckBoxes');
  }

  get surfacesArray() {
    return <FormArray>this.reactiveForm.get('surfacesCheckBoxes');
  }

  getSelectedFacilitiesValue() {
    this.selectedFacilitiesValues = [];
    this.facilitiesArray.controls.forEach((control, i) => {
      if (control.value) {
        this.selectedFacilitiesValues.push(this.facilities[i]);
      }
    });
  }

  getSelectedSurfacesValue() {
    this.selectedSurfacesValues = [];
    this.surfacesArray.controls.forEach((control, i) => {
      if (control.value) {
        this.selectedSurfacesValues.push(this.surfaces[i]);
      }
    });
  }

  checkFormControlTouched(dataArray: FormArray) {
    let flg = false;
    dataArray.controls.forEach((control) => {
      if (control.touched) {
        flg = true;
      }
    });
    return flg;
  }

  noFilterOptionSelected() {
    return (this.selectedFacilitiesValues?.length === 0 &&
      this.selectedSurfacesValues?.length === 0) ||
      (!this.selectedFacilitiesValues && !this.selectedSurfacesValues)
      ? true
      : false;
  }

  handleErrorMessage() {
    let errorElement = document.getElementById('errorFilterElement');
    this.noFilterOptionSelected()
      ? (errorElement.style.display = 'block')
      : (errorElement.style.display = 'none');
  }

  submitHandler() {
    this.handleErrorMessage();
    const newQuerySurfaces = this.selectedSurfacesValues;
    const allOptions = newQuerySurfaces;
    if (this.reactiveForm.valid && allOptions) {
      console.log(this.reactiveForm.value, allOptions);
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
          facilitiesCheckBoxes: this.addFormControl(this.facilities),
        });
        this.initForm();
      });
  }

  loadSurfaces(cityId: number) {
    return this.tennisClubService
      .getSurfacesForTennisClubsPerCity(cityId)
      .subscribe((surfaces) => {
        this.surfaces = surfaces;
        this.reactiveForm = this.formBuilder.group({
          surfacesCheckBoxes: this.addFormControl(surfaces),
        });
        this.initForm();
      });
  }

  subscribeRouteChange() {
    this.route.params.subscribe((params = {}) => {
      this.loadAllData(params.cityId);
      this.data.changeMessage(params.cityId);
    });
  }
}
