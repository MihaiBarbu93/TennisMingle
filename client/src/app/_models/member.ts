import { UserType } from './enums/userType';
import { Photo } from './photo';
import { City } from './city';
import { Booking } from './booking';
import { BookingFromDb } from './bookingFromDb';

export interface Member {
  id: number;
  username: string;
  age: Date;
  city: City;
  photoUrl: string;
  roles: string[]
  bookings: BookingFromDb[];
}