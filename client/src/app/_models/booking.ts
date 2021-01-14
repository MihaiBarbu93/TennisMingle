export interface Booking {
  id: number;
  dateStart: Date;
  dateEnd: Date;
  tennisCourtId: number;
  confirmed: boolean;
  userId: number;
  firstName: string;
  lastName: string;
  phoneNumber: string;
}
