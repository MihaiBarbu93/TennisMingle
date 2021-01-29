import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Booking } from '../_models/booking';
import { BookingService } from '../_services/booking.service';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/user';
import * as moment from 'moment';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

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
  minDate = new Date();


  

  constructor(
    private bookingService: BookingService,
    public accountService: AccountService,
    public datepipe: DatePipe,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.bookingForm = new FormGroup({
      FirstName: new FormControl(this.model.firstName, [Validators.required, Validators.minLength(3)]),
      LastName: new FormControl(this.model.lastName, [Validators.required, Validators.minLength(3)]),
      Email: new FormControl(this.model.email, [Validators.required, Validators.minLength(5)]),
      PhoneNumber: new FormControl(this.model.phoneNumber, [Validators.required,Validators.minLength(5),Validators.pattern('^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$')]),
      DateStart: new FormControl(this.model.dateStart, Validators.required),
      Time: new FormControl(this.model.time, Validators.required),
      Duration: new FormControl(this.model.duration, Validators.required),
    });


 
    }
  get firstName() {
    return this.bookingForm.get('FirstName');
  }
  get lastName() {
    return this.bookingForm.get('LastName');
  }
  get email(){
    return this.bookingForm.get('email');
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
    if (this.bookingForm.valid) {
      return this.bookingService
        .book(this.model, this.tennisClubFromDetail)
    } else {
      this.bookingForm.markAllAsTouched();
    }
  }
}
