import { UserType } from './enums/userType';
import { Photo } from './photo';
import { City } from './city';
import { Booking } from './booking';


export interface UserForRegister {
  
  username: string;
  token: string;
  dateOfbirth: Date;
  city: City;
  usertype: UserType;
  
}