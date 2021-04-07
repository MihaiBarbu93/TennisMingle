import { TennisCourt } from "./tennisCourt";

export interface BookingFromDb {
  id: number;
  title: string;
  dateStart: Date;
  dateEnd: Date;
  tennisCourt: TennisCourt;
}
