import { UserType } from './enums/userType';
import { Photo } from './photo';
import { City } from './city';
import { Booking } from './booking';

export interface Member {
  id: number;
  userName: string;
  dateOfBirth: Date;
  city: City;
  userType: UserType;
  bookings: Booking[];
}