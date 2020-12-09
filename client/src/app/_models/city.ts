import { TennisClub } from './tennisClub';
export interface City {
  id: number;
  name: string;
  tennisClubs: TennisClub[];
}
