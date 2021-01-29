import { UserType } from './enums/userType';
import { Photo } from './photo';
import { City } from './city';
import { Booking } from './booking';

export interface UserForRegister {
  username: string;
  password: string;
  token: string;
  dateofbirth: Date;
  city: City;
  userType: UserType;
}
