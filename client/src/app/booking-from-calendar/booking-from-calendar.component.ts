import { ModalModule } from 'ngx-bootstrap/modal';
import { AfterViewChecked, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BookingService } from '../_services/booking.service';
import { TennisClub } from '../_models/tennisClub';
import { isThisMinute } from 'date-fns';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BehaviorSubject, Observable } from 'rxjs';
import { CalendarEvent } from 'angular-calendar';
import { BookingFromDb } from '../_models/bookingFromDb';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking-from-calendar',
  templateUrl: './booking-from-calendar.component.html',
  styleUrls: ['./booking-from-calendar.component.css'],
})
export class BookingFromCalendarComponent implements OnInit {
  @Input() modalRefFromBookingCalendarComponent: any;
  @Input() tennisClubFromDetail: any;
  @Input() viewDate: any;
  
  @Output() childEvents: Observable<CalendarEvent<{ booking: BookingFromDb }>[]>;
  @Output() newBooking = new EventEmitter<any>();
  @Input() tennisClubId: any;
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
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private modal: NgbModal,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.createForm();
    this.myDateValue = new Date();
    this.setDateAndTime();

  }

  addNewBooking(childEvents: Observable<CalendarEvent<{ booking: BookingFromDb }>[]>) {
    this.newBooking.emit(childEvents);
  }

  private createForm() {
    this.bookingForm = this.formBuilder.group({
      FirstName: [
        this.model.firstName,
        [Validators.required, Validators.minLength(3)],
      ],
      LastName: [
        this.model.lastName,
        [Validators.required, Validators.minLength(3)],
      ],
      PhoneNumber: [
        this.model.phoneNumber,
        [
          Validators.required,
          Validators.minLength(5),
          Validators.pattern('^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-s./0-9]*$'),
        ],
      ],
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

  

  async bookCourt() {
    if (this.bookingForm.valid) {
      let booking = this.bookingService.convertModelToBooking(this.model, this.tennisClubFromDetail);
      this.bookingService.CheckAvailability(booking, this.tennisClubFromDetail).subscribe(async item=>{
      if (item>0){
        booking.tennisCourtId = item;
        return this.bookingService
          .book(this.tennisClubFromDetail, booking).subscribe(x=>{ console.log("x:", x); 
          this.router.navigateByUrl('load-calendar-component', { skipLocationChange: true }).then(() => {
            this.router.navigate(['cities/'+this.tennisClubFromDetail.cityId+'/tennis-clubs/'+this.tennisClubId]);
        });
          
          
          
          this.addNewBooking(this.bookingService.fetchEvents(this.tennisClubId))});  
      }else{
        this.toastr.error("No courts available");
      } });
     //(this.tennisClubFromDetail, booking).toPromise().then(x=>this.fetchEvents);
      this.modal.dismissAll();
      
      // this.fetchEvents.toPromise().then(x=>x)
    } else {
      this.bookingForm.markAllAsTouched();
    }
  }
}
