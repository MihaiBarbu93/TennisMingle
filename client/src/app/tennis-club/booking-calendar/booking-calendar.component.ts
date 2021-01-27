import { BookingService } from './../../_services/booking.service';
import {
  Component,
  ChangeDetectionStrategy,
  ViewChild,
  TemplateRef,
  OnInit,
  Output,
  EventEmitter,
  Input,
  ChangeDetectorRef,
} from '@angular/core';
import {
  startOfDay,
  endOfDay,
  subDays,
  addDays,
  endOfMonth,
  isSameDay,
  isSameMonth,
  addHours,
  getHours,
  startOfMonth,
  startOfWeek,
  endOfWeek,
  format,
} from 'date-fns';
import { Observable, of, Subject } from 'rxjs';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import {
  CalendarDayViewBeforeRenderEvent,
  CalendarEvent,
  CalendarEventAction,
  CalendarEventTimesChangedEvent,
  CalendarMonthViewBeforeRenderEvent,
  CalendarMonthViewDay,
  CalendarView,
  CalendarWeekViewBeforeRenderEvent,
} from 'angular-calendar';
import { Event } from 'jquery';
import { Booking } from 'src/app/_models/booking';
import { TennisClubsService } from 'src/app/_services/tennis-clubs.service';
import { ActivatedRoute } from '@angular/router';
import { TennisClub } from 'src/app/_models/tennisClub';
import { HttpParams, HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { datepickerAnimation } from 'ngx-bootstrap/datepicker/datepicker-animations';

interface BookingFromDb {
  id: number;
  dateStart: string;
  dateEnd: string;
}

function getTimezoneOffsetString(date: Date): string {
  const timezoneOffset = date.getTimezoneOffset();
  const hoursOffset = String(
    Math.floor(Math.abs(timezoneOffset / 60))
  ).padStart(2, '0');
  const minutesOffset = String(Math.abs(timezoneOffset % 60)).padEnd(2, '0');
  const direction = timezoneOffset > 0 ? '-' : '+';

  return `T00:00:00${direction}${hoursOffset}:${minutesOffset}`;
}

@Component({
  selector: 'app-booking-calendar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './booking-calendar.component.html',
  styleUrls: ['./booking-calendar.component.css'],
})
export class BookingCalendarComponent implements OnInit {
  @Input() tennisClubFromDetail: any;
  @Input() allBookings: Booking[];
  @ViewChild('modalContent', { static: true }) modalContent: TemplateRef<any>;

  view: CalendarView = CalendarView.Week;

  viewDate: Date = new Date();

  events$: Observable<CalendarEvent<{ booking: BookingFromDb }>[]>;

  activeDayIsOpen: boolean = false;

  tennisClubId: number;
  cityId: number;
  modalReference: any;
  baseUrl = 'https://localhost:5001/api/';

  constructor(
    private modal: NgbModal,
    private bookingService: BookingService,
    private cdr: ChangeDetectorRef,
    private tennisClubService: TennisClubsService,
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}
  ngOnInit(): void {
    this.cityId = +this.route.snapshot.params.cityId;
    this.tennisClubId = +this.route.snapshot.params.id;
    this.fetchEvents();
  }

  fetchEvents(): void {
    const getStart: any = {
      month: startOfMonth,
      week: startOfWeek,
      day: startOfDay,
    }[this.view];

    const getEnd: any = {
      month: endOfMonth,
      week: endOfWeek,
      day: endOfDay,
    }[this.view];

    this.events$ = this.http.get<any>(this.baseUrl + '28/booking').pipe(
      map((results: BookingFromDb[]) => {
        return results.map((booking: BookingFromDb) => {
          console.log(booking);
          return {
            title: 'unavailable',
            start: new Date(booking.dateStart),
            end: new Date(booking.dateEnd),
          };
        });
      })
    );
  }

  dayClicked({
    date,
    events,
  }: {
    date: Date;
    events: CalendarEvent<{ booking: BookingFromDb }>[];
  }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
        this.viewDate = date;
      }
    }
  }

  startBooking(event) {
    console.log(typeof event.date.getHours());
    if (event.date.getHours() > 7 && event.date.getHours() < 23) {
      this.viewDate = event.date;
      console.log(this.viewDate);
      this.modal.open(this.modalContent, { size: 'lg' });
    }
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

  @Output() hourSegmentClicked = new EventEmitter<{
    date: Date;
    sourceEvent: MouseEvent;
  }>();

  submit() {
    this.modalReference.open();
  }

  close() {
    this.modalReference.close();
  }
}
