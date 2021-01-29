import { map } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TennisClub } from 'src/app/_models/tennisClub';
import { DataService } from 'src/app/_services/data-service.service';
import { TennisClubsService } from 'src/app/_services/tennis-clubs.service';
import { FacilityType } from 'src/app/_models/enums/facilityType';
import { Facility } from 'src/app/_models/facility';
import { AgmCoreModule } from '@agm/core';
import {
  faSearch,
  faCalendar,
  faRunning,
  faCheck,
  faMapMarked,
  faChevronLeft,
  faCheckCircle,
  faBus,
  faTram,
  faBaseballBall,
  faEnvelope,
  faMap,
} from '@fortawesome/free-solid-svg-icons';
import { Booking } from 'src/app/_models/booking';
import { BookingService } from 'src/app/_services/booking.service';

@Component({
  selector: 'app-tennis-club-detail',
  templateUrl: './tennis-club-detail.component.html',
  styleUrls: ['./tennis-club-detail.component.css'],
})
export class TennisClubDetailComponent implements OnInit {
  tennisClubs : TennisClub[] = [];
  model: any = {};
  tennisClub!: TennisClub;
  tennisClubId: number;
  cityId: number;
  faSearch = faSearch;
  faCalendar = faCalendar;
  faRunning = faRunning;
  faMapMarked = faMapMarked;
  faCheck = faCheck;
  faChevronLeft = faChevronLeft;
  faCheckCircle = faCheckCircle;
  faBus = faBus;
  faTram = faTram;
  faBaseballBall = faBaseballBall;
  faEnvelope = faEnvelope;
  faMap = faMap;
  lat: number;
  lng: number;
  allBookings: Booking[];

  facilities: any[] = [];
  reactiveForm!: FormGroup;
  locationChosen = false;

  onChoseLocation(event) {
    this.lat = event.coords.lat;
    this.lng = event.coords.lng;
    this.locationChosen = true;
  }

  constructor(
    private tennisClubService: TennisClubsService,
    private route: ActivatedRoute,
    private bookingService: BookingService
  ) {}

  ngOnInit(): void {
    this.cityId = +this.route.snapshot.params.cityId;
    this.tennisClubId = +this.route.snapshot.params.id;
    this.loadTennisClub(this.cityId, this.tennisClubId);
  }

  ngOnChanges() {
    this.loadTennisClub(this.cityId, this.tennisClubId);
    console.log(this.allBookings);
    this.getHoursForBooking(this.allBookings);
  }

  ngAfterContentInit() {}

  loadTennisClub(cityId: number, tennisClubId: number) {
    return this.tennisClubService
      .getTennisClubById(cityId, tennisClubId)
      .subscribe((tennisClub) => {
        this.tennisClub = tennisClub;
        this.getFacilityTypes(tennisClub.facilities);
        this.lat = this.tennisClub.geoLat;
        this.lng = this.tennisClub.geoLong;
        console.log('maaasa');
        this.loadAllBookings(28);
      });
  }

  loadAllBookings(tennisClubId: number) {
    let bookingsModified = [];
    let allBookings = this.bookingService.getBookingsForAClub(tennisClubId);

    allBookings
      .pipe(
        map((booking) =>
          booking.map((booking) => {
            booking['dateStart'] = new Date();
          })
        )
      )
      .subscribe((bookings) => {
        this.allBookings = bookings;
      });
  }

  getHoursForBooking(bookings: Booking[]) {
    let bookingHours = [];
    bookings.forEach((element) => {
      bookingHours.push(element[1].getHours());
    })
  }

      
  loadTennisClubs(cityId: number, tennisClubId: number){
    return this.tennisClubService.getTennisClubs(cityId).subscribe((tennisClubs)=>{
      this.tennisClubs = tennisClubs;
      this.tennisClubs.filter(tc => tc.id !== tennisClubId);
    });
  }

  getFacilityTypes(fac: any) {
    this.facilities = Object.keys(fac)
      .map((key) => FacilityType[key])
      .filter((value) => typeof value === 'string') as string[];
  }
}
