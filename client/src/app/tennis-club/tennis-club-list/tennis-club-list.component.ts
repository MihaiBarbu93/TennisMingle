import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from './../../_services/data-service.service';
import { City } from './../../_models/city';
import { TennisClubsService } from './../../_services/tennis-clubs.service';
import { Component, Input, OnInit } from '@angular/core';
import { TennisClub } from 'src/app/_models/tennisClub';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { isEmpty } from 'rxjs/operators';
import { analyzeAndValidateNgModules } from '@angular/compiler';

@Component({
  selector: 'app-tennis-club-list',
  templateUrl: './tennis-club-list.component.html',
  styleUrls: ['./tennis-club-list.component.css'],
})
export class TennisClubListComponent implements OnInit {
  tennisClubs: TennisClub[] = [];
  tennisClubs$: Observable<any>;
  cityId!: number;
  facilities: string[] = [];
  surfaces: string[] = [];
  reactiveForm!: FormGroup;
  selectedFacilitiesValues: string[] = [];
  selectedFacilitiesError: boolean = true;
  selectedSurfacesValues: string[] = [];
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
        console.log(
          this.selectedFacilitiesValues[
            this.selectedFacilitiesValues.length - 1
          ]
        );
      }
    });
    this.loadTennisClubs(this.cityId);
  }

  getSelectedSurfacesValue() {
    this.selectedSurfacesValues = [];
    this.surfacesArray.controls.forEach((control, i) => {
      if (control.value) {
        this.selectedSurfacesValues.push(this.surfaces[i]);
      }
    });
    console.log(
      this.selectedSurfacesValues[this.selectedSurfacesValues.length - 1]
    );
    this.loadTennisClubs(this.cityId);
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

  // handleErrorMessage() {
  //   let errorElement = document.getElementById('errorFilterElement');
  //   this.noFilterOptionSelected()
  //     ? (errorElement.style.display = 'block')
  //     : (errorElement.style.display = 'none');
  // }

  // submitHandler() {
  //   this.handleErrorMessage();
  //   const allOptions = this.selectedFacilitiesValues.concat(
  //     this.selectedSurfacesValues
  //   );
  //   if (allOptions.length > 0) {
  //     // this.tennisClubs = this.tennisClubs.filter((tc) => tc.includ);
  //   }
  // }

  loadAllData(cityId: number) {
    this.loadTennisClubs(cityId);
    this.loadFacilities(cityId);
    this.loadSurfaces(cityId);
  }

  loadTennisClubs(cityId: number) {
    console.log(this.selectedFacilitiesValues.length);
    console.log(this.selectedSurfacesValues.length);
    if (this.tennisClubs.length === 0) {
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
              console.log(tennisClubs);
            });
    } else {
      if (
        this.tennisClubs[0].cityId === cityId &&
        (this.selectedSurfacesValues.length !== 0 ||
          this.selectedFacilitiesValues.length !== 0)
      ) {
        this.tennisClubs = this.tennisClubs.filter(
          (tc) => tc == this.tennisClubs[this.tennisClubs.length - 1]
        );
      } else
        this.router.url.includes('courts')
          ? this.tennisClubService
              .getTennisClubsWithCourtsAvailable(cityId)
              .subscribe((tennisClubs) => {
                this.tennisClubs = tennisClubs;
              })
          : this.tennisClubService
              .getTennisClubs(cityId)
              .subscribe((tennisClubs) => {
                this.tennisClubs = tennisClubs;
                console.log(tennisClubs);
              });
    }
  }

  // loadTennisClubsAsyncPipe(cityId: number) {
  //   if (this.tennisClubs$ === undefined) {
  //     this.router.url.includes('courts')
  //       ? (this.tennisClubs$ = this.tennisClubService.getTennisClubsWithCourtsAvailable(
  //           cityId
  //         ))
  //       : (this.tennisClubs$ = this.tennisClubService.getTennisClubs(cityId));
  //   } else {
  //     this.tennisClubs$ = new Observable<any>();
  //   }
  // }

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
