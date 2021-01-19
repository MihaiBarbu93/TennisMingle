import { City } from './city';
import { Facility } from './facility';
import { Photo } from './photo';
import { TennisCourt } from './tennisCourt';
import { User } from './user';

export interface TennisClub {
  id: number;
  name: string;
  phoneNumber: string;
  city: City;
  cityId: number;
  address: string;
  description: string;
  schedule: string;
  price: number;
  tennisCourts: TennisCourt[];
  facilities: Facility[];
  photos: Photo[];
  users: User[];
  location: any;
  geoLat: number;
  geoLong: number;
}
