import { UserType } from './enums/userType';
import { Photo } from './photo';
import { City } from './city';
import { Booking } from './booking';

export interface User {
  id: number;
  userName: string;
  token: string;
  roles: string[];
  knownAs: string;
  gender: string;
  //id: number;
  // dateOfBirth: Date;
  // city: City;
  // bio: string;
  // photo: Photo;
  // userType: UserType;
  // bookings: Booking[];
  // tennisClubId: number;
}
