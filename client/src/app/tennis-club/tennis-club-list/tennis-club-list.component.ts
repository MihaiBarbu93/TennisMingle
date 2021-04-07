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
import { FacilityType } from './../../_models/enums/facilityType';

@Component({
  selector: 'app-tennis-club-list',
  templateUrl: './tennis-club-list.component.html',
  styleUrls: ['./tennis-club-list.component.css'],
})
export class TennisClubListComponent implements OnInit {
  tennisClubs: TennisClub[] = [];
  unfilteredTennisClubs: TennisClub[] = [];
  cityId!: number;
  facilities: string[] = [];
  surfaces: string[] = [];
  reactiveForm!: FormGroup;
  selectedFacilitiesValues: number[] = [];
  selectedFacilitiesError: boolean = true;
  selectedSurfacesValues: number[] = [];
  selectedSurfacesError: boolean = true;
  filteringStarted: boolean = false;
  allFacilities: string[] = [
    'PARKING',
    'TOILETS',
    'DRESSROOM',
    'SHOWERS',
    'STANDS',
    'NOCTURNE',
    'OUTDOOR_LAND',
    'BAR',
    'TERRASE',
    'WI_FI',
    'RESTAURANT',
  ];
  allSurfaces: string[] = [
    'ACRYLIC',
    'ARTIFICIAL_CLAY',
    'ARTIFICIAL_GRASS',
    'ASPHALT',
    'CARPET',
    'CLAY',
    'CONCRETE',
    'GRASS',
  ];

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
        this.selectedFacilitiesValues.push(
          this.allFacilities.indexOf(this.facilities[i])
        );
      }
    });
    this.loadTennisClubs(this.cityId);
  }

  getSelectedSurfacesValue() {
    this.selectedSurfacesValues = [];
    this.surfacesArray.controls.forEach((control, i) => {
      if (control.value) {
        this.selectedSurfacesValues.push(
          this.allSurfaces.indexOf(this.surfaces[i])
        );
      }
    });
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

  loadAllData(cityId: number) {
    this.loadTennisClubs(cityId);
    this.loadFacilities(cityId);
    this.loadSurfaces(cityId);
  }

  loadTennisClubs(cityId: number) {
    if (this.tennisClubs.length === 0 && !this.filteringStarted) {
      return this.InitialTennisClubsLoad(cityId);
    } else {
      if (
        this.tennisClubs[0]?.cityId === cityId &&
        (this.selectedSurfacesValues.length !== 0 ||
          this.selectedFacilitiesValues.length !== 0)
      ) {
        this.StartFiltering();
      } else if (this.tennisClubs.length === 0 && this.filteringStarted) {
        this.ReversedFiltering();
      } else {
        this.ResetFiltering(cityId);
      }
    }
  }

  private InitialTennisClubsLoad(cityId: number) {
    return this.router.url.includes('courts')
      ? this.LoadTennisClubsWithCourtsAvailable(
          cityId,
          this.tennisClubs,
          this.unfilteredTennisClubs
        )
      : this.LoadAllTennisClubs(
          cityId,
          this.tennisClubs,
          this.unfilteredTennisClubs
        );
  }

  private StartFiltering() {
    this.filteringStarted = true;
    this.tennisClubs = this.tennisClubs.filter(
      (tc) => this.ApplyFilteredFacilities(tc) && this.ApplyFilteredSurfaces(tc)
    );
  }

  private ReversedFiltering() {
    this.tennisClubs = this.unfilteredTennisClubs;
    this.tennisClubs = this.tennisClubs.filter(
      (tc) => this.ApplyFilteredFacilities(tc) && this.ApplyFilteredSurfaces(tc)
    );
  }

  private ResetFiltering(cityId: number) {
    this.router.url.includes('courts')
      ? this.LoadTennisClubsWithCourtsAvailable(cityId, this.tennisClubs)
      : this.LoadAllTennisClubs(cityId, this.tennisClubs);
  }

  private LoadTennisClubsWithCourtsAvailable(
    cityId: number,
    tennisClubs: TennisClub[],
    unfilteredTennisClubs?: TennisClub[]
  ) {
    return this.tennisClubService
      .getTennisClubsWithCourtsAvailable(cityId)
      .subscribe((tennisClubs) => {
        this.tennisClubs = tennisClubs;
        this.unfilteredTennisClubs = tennisClubs;
      });
  }

  private LoadAllTennisClubs(
    cityId: number,
    tennisClubs: TennisClub[],
    unfilteredTennisClubs?: TennisClub[]
  ) {
    return this.tennisClubService
      .getTennisClubs(cityId)
      .subscribe((tennisClubs) => {
        this.tennisClubs = tennisClubs;
        this.unfilteredTennisClubs = tennisClubs;
      });
  }

  private ApplyFilteredFacilities(tc: TennisClub) {
    return this.selectedFacilitiesValues.every((fac) =>
      tc.facilities.some(
        (tcfac) => tcfac.facilityType.toString() == fac.toString()
      )
    );
  }

  private ApplyFilteredSurfaces(tc: TennisClub): unknown {
    return this.selectedSurfacesValues.every((surface) =>
      tc.tennisCourts.some(
        (tco) => tco.surface.surfaceType.toString() == surface.toString()
      )
    );
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
