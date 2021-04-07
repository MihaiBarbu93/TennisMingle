import { Surface } from './surface';
import { TennisClub } from './tennisClub';

export interface TennisCourt {
  id: number;
  name: string;
  surface: Surface;
  surfaceId: number;
  isAvailable: boolean;
  tennisClubId: number;
  tennisClub: TennisClub;
}
