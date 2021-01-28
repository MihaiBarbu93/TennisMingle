import { Injectable } from '@angular/core';
import { Booking } from '../_models/booking';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { User } from '../_models/user';
import { TennisCourt } from '../_models/tennisCourt';
import { TennisClub } from '../_models/tennisClub';
import { AccountService } from './account.service';
import { map, take } from 'rxjs/operators';
import { City } from '../_models/city';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  booking: Booking;
  baseUrl = 'https://localhost:5001/api/';
  user: User;
  tennisCourtId : number;

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
    this.CheckAvailability(model, tennisClub)
    if (this.tennisCourtId>0){
      this.booking.tennisCourtId = this.tennisCourtId;
      console.log("Booking complete");
      return this.http.post<any>(
        this.baseUrl + tennisClub.id + '/booking',
        this.booking
      ).subscribe(data => console.log('data', data),
      err => console.log('error', err),
      () => console.log('Complete!'));
    }else{
      console.log("No courts available");
    }
  }

  getBookingsForAClub(tennisClubId: number) {
    return this.http.get<any>(this.baseUrl + tennisClubId + '/booking');
  }

  convertModelToBooking(model: any, tennisClub: TennisClub) {
    let booking = <Booking>{};
    booking.firstName = model.firstName;
    booking.lastName = model.lastName;
    booking.email = model.email;
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
    // booking.tennisCourtId = tennisClub.tennisCourts.find(tc=>tc).id;
    return booking;
  
  }

  CheckAvailability(model: any, tennisClub: TennisClub){
    return this.http.post<number>(
      this.baseUrl  + tennisClub.id + '/booking/check-availability', this.booking
    ).pipe(take(1)).subscribe(item => this.tennisCourtId=item);
  }
}
