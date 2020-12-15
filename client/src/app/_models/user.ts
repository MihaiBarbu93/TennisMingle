import { UserType } from './enums/userType';
import { Photo } from './photo';
import { City } from './city';
import { Booking } from './booking';


export interface User {
  
  userName: string;
  token: string;
  knownAs: string;
  //id: number;
  // dateOfBirth: Date;
  // city: City;
  // bio: string;
  // photo: Photo;
  // userType: UserType;
  // bookings: Booking[];
  // tennisClubId: number;
  
}
