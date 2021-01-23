import { Injectable } from '@angular/core';
import { Booking } from '../_models/booking';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { User } from '../_models/user';
import { TennisCourt } from '../_models/tennisCourt';
import { TennisClub } from '../_models/tennisClub';
import { AccountService } from './account.service';
import { map, take } from 'rxjs/operators';
import { City } from '../_models/city';

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  booking: Booking;
  baseUrl = 'https://localhost:5001/api/';
  user: User;

  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {
    this.accountService.currentUser$
      .pipe(take(1))
      .subscribe((user) => (this.user = user));
  }

  book(model: any, tennisClub: TennisClub) {
    this.booking = this.convertModelToBooking(model, tennisClub);
    console.log(this.booking);
    // var ceva = this.http
    //   .get<City>(this.baseUrl + 'cities/' + 1)
    //   .subscribe((data) => {
    //     console.log(data); // ONLY WORKS ONCE
    //   });
    // console.log(ceva);
    // return this.http.post<any>(this.baseUrl + 'account/login', this.booking);
    return this.http.post<any>(
      this.baseUrl + tennisClub.id + '/booking',
      this.booking
    );
  }

  convertModelToBooking(model: any, tennisClub: TennisClub) {
    let booking = <Booking>{};
    booking.firstName = model.firstName;
    booking.lastName = model.lastName;
    booking.userName = this.user.userName;
    console.log(this.user.userName);
    booking.phoneNumber = model.phoneNumber;
    booking.dateStart = model.dateStart;
    booking.dateStart.setHours(
      model.time.getHours() + 2,
      model.time.getMinutes()
    );

    booking.dateEnd = new Date(model.dateStart);
    booking.dateEnd.setHours(
      Number(booking.dateStart.getHours()) + Number(model.duration)
    );
    // booking.tennisCourtId = tennisClub.tennisCourts.find(
    //   (tc) => tc.isAvailable === true
    // ).id;
    booking.tennisCourtId = tennisClub.id;
    console.log(booking);
    return booking;
  }
}
