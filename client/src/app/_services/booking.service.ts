import { Injectable } from '@angular/core';
import { Booking } from '../_models/booking';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  baseUrl = 'https://localhost:5001/api/';
  booking : Booking;

  constructor(private http: HttpClient) { }

  book(model: any, tennisClubId) {
    return this.http
      .post<Booking>(this.baseUrl + tennisClubId +'/booking', model)
  }
}
