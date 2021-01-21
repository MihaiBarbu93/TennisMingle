import { Injectable } from '@angular/core';
import { Booking } from '../_models/booking';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { User } from '../_models/user';
import { TennisCourt } from '../_models/tennisCourt';
import { TennisClub } from '../_models/tennisClub';
import { AccountService } from './account.service';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  booking: Booking;
  baseUrl = 'https://localhost:5001/api/';
  user: User;


  constructor(private http: HttpClient,private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
   }

  book(model: any, tennisClub: TennisClub) {
    this.booking = this.convertModelToBooking(model, tennisClub);
    return this.http
      .post<any>(this.baseUrl + tennisClub.id +'/booking',this.booking);
  }

  convertModelToBooking(model:any, tennisClub: TennisClub){
    let booking = <Booking> {};
    booking.firstName =model.firstName;
    booking.lastName =model.lastName;
    booking.userName = this.user.username;
    booking.phoneNumber =model.phoneNumber;
    booking.dateStart = model.dateStart;
    booking.dateStart.setHours(model.time.getHour);
    booking.dateStart.setMinutes(model.time.getMinutes);
    booking.dateEnd = model.dateStart;
    booking.dateEnd.setHours(booking.dateStart.getHours() + model.duration);
    booking.tennisCourtId = tennisClub.tennisCourts.find((tc) => tc.isAvailable === true).id;
    console.log(booking);
    return booking;
  }


}
