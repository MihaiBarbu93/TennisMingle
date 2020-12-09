import { Surface } from './surface';

export interface TennisCourt {
  id: number;
  name: string;
  surface: Surface;
  surfaceId: number;
  isAvailable: boolean;
  tennisClubId: number;
}
