import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Booking } from '../_models/booking';
import { BookingService } from '../_services/booking.service';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/user';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
})
export class BookingComponent implements OnInit {
  @Input() tennisClubFromDetail: any;
  model: any = {};
  bookingHours: number[] = [1, 2, 3];
  bookingForm: FormGroup;
  myDateValue: Date;
  previousDate: Date;

  constructor(
    private bookingService: BookingService,
    public accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.bookingForm = new FormGroup({
      FirstName: new FormControl(this.model.firstName, Validators.required),
      LastName: new FormControl(this.model.lastName, Validators.required),
      PhoneNumber: new FormControl(this.model.phoneNumber, Validators.required),
      DateStart: new FormControl(this.model.dateStart, Validators.required),
      Time: new FormControl(this.model.time, Validators.required),
      Duration: new FormControl(this.model.duration, Validators.required),
    });
    this.myDateValue = new Date();
  }
  get firstName() {
    return this.bookingForm.get('FirstName');
  }
  get lastName() {
    return this.bookingForm.get('LastName');
  }
  get phoneNumber() {
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
