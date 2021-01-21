import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Booking } from '../_models/booking';
import { BookingService } from '../_services/booking.service';
import * as $ from 'jquery';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  @Input() tennisClubFromDetail: any;
  model: any={};
  bookingHours: number[] = [1,2,3];
  bookingForm: FormGroup;
  

  constructor( private bookingService: BookingService) { }

  ngOnInit(): void {
    this.bookingForm =new FormGroup({
      FirstName: new FormControl('', Validators.required),
      LastName: new FormControl('', Validators.required),
      PhoneNumber: new FormControl('',Validators.required),
      DateStart: new FormControl('',Validators.required),
      TimeStart: new FormControl('',Validators.required),
      Duration: new FormControl('',Validators.required),
    });
  }

  Book(){
    if(!this.bookingForm.invalid){
      this.bookingService.book(this.model, this.tennisClubFromDetail.Id);
      console.log("Booking complete")
    }else{
      console.log("Booking form invalid")
      this.bookingForm.markAllAsTouched();
      console.log(this.bookingForm);
    }
}

}
