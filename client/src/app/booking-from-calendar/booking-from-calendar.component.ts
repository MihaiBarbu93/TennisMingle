import { ModalModule } from 'ngx-bootstrap/modal';
import { AfterViewChecked, Component, Input, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BookingService } from '../_services/booking.service';
import { TennisClub } from '../_models/tennisClub';

@Component({
  selector: 'app-booking-from-calendar',
  templateUrl: './booking-from-calendar.component.html',
  styleUrls: ['./booking-from-calendar.component.css'],
})
export class BookingFromCalendarComponent implements OnInit {
  @Input() tennisClubFromDetail: any;
  @Input() viewDate: any;
  model: any = {};
  bookingHours: number[] = [1, 2, 3];
  bookingForm: FormGroup;
  myDateValue: Date;
  previousDate: Date;
  timeInitial: { hour: number; minutes: number } = { hour: 5, minutes: 24 };
  tennisClub: TennisClub;

  constructor(
    private bookingService: BookingService,
    public accountService: AccountService,
    private formBuilder: FormBuilder
  ) {}
  ngOnInit(): void {
    this.createForm();
    this.myDateValue = new Date();
    this.setDateAndTime();
  }

  private createForm() {
    this.bookingForm = this.formBuilder.group({
      FirstName: [this.model.firstName, Validators.required],
      LastName: [this.model.lastName, Validators.required],
      PhoneNumber: [this.model.phoneNumber, Validators.required],
      DateStart: [this.model.dateStart],
      Time: [this.model.time],
      Duration: [this.model.duration, Validators.required],
    });
  }

  private setDateAndTime() {
    const time = new Date();
    time.setHours(this.viewDate.getHours());
    time.setMinutes(this.viewDate.getMinutes());
    this.model.time = time;
    this.model.dateStart = this.viewDate;
  }

  get firstName() {
    return this.bookingForm.get('FirstName');
  }
  get lastName() {
    return this.bookingForm.get('LastName');
  }
  get phoneNumber() {
    console.log('ftumppooss');
    return this.bookingForm.get('PhoneNumber');
  }
  get dateStart() {
    return this.bookingForm.get('DateStart');
  }
  get time() {
    return this.bookingForm.get('Time');
  }
  get duration() {
    return this.bookingForm.get('Duration');
  }

  onDateChange(newDate: Date) {
    this.previousDate = new Date(newDate);
  }

  bookCourt() {
    if (!this.bookingForm.invalid) {
      this.bookingService
        .book(this.model, this.tennisClubFromDetail)
        .subscribe((response) => {
          console.log(response);
        });
      console.log('Booking complete');
    } else {
      console.log('Booking form invalid');
      this.bookingForm.markAllAsTouched();
      console.log(this.bookingForm);
    }
  }
}
