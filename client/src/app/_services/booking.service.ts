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
import { ToastrService } from 'ngx-toastr';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  booking: Booking;
  baseUrl = 'https://localhost:5001/api/';
  user: User;
  tennisCourtId: number;
  private subjects: Subject<string>[] = [];

  constructor(
    private http: HttpClient,
    private accountService: AccountService,
    private toastr: ToastrService
  ) {
    this.accountService.currentUser$
      .pipe(take(1))
      .subscribe((user) => (this.user = user));
  }

  publish(eventName: string) {
    // ensure a subject for the event name exists
    this.subjects[eventName] = this.subjects[eventName] || new Subject();

    // publish event
    this.subjects[eventName].next();
  }

  on(eventName: string): Observable<string> {
    // ensure a subject for the event name exists
    this.subjects[eventName] = this.subjects[eventName] || new Subject();

    // return observable
    return this.subjects[eventName].asObservable();
  }

  book(tennisClub: TennisClub, booking: Booking) {
    return this.http.post<any>(
      this.baseUrl + tennisClub.id + '/booking',
      booking
    );
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

  CheckAvailability(booking: Booking, tennisClub: TennisClub) {
    var tennisCourtId = this.http.post<number>(
      this.baseUrl + tennisClub.id + '/booking/check-availability',
      booking
    );
    console.log('check avalb', tennisCourtId);
    return tennisCourtId;
  }
}
