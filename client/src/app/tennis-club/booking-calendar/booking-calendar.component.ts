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
} from 'date-fns';
import { Subject } from 'rxjs';
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

const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
};
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
  modalReference: NgbModalRef;

  CalendarView = CalendarView;

  viewDate: Date = new Date();

  clickedDate: Date;
  dayStartHour = Math.max(8);

  dayEndHour = Math.min(22);
  tennisClubId: number;
  cityId: number;

  allBookingsArrive: boolean = false;

  modalData: {
    action: string;
    event: CalendarEvent;
  };

  actions: CalendarEventAction[] = [
    {
      label: '<i class="fas fa-fw fa-pencil-alt"></i>',
      a11yLabel: 'Edit',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Edited', event);
      },
    },
    {
      label: '<i class="fas fa-fw fa-trash-alt"></i>',
      a11yLabel: 'Delete',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.events = this.events.filter((iEvent) => iEvent !== event);
        this.handleEvent('Deleted', event);
      },
    },
  ];

  refresh: Subject<any> = new Subject();

  events: CalendarEvent[] = [
    {
      start: startOfDay(new Date()),
      title: 'pulaaaa',
      color: colors.yellowsunflower,
      id: '1',
    },
    {
      start: subDays(startOfDay(new Date()), 1),
      end: addDays(new Date(), 1),
      title: 'A 3 day event',
      color: colors.red,
      actions: this.actions,
      allDay: true,
      resizable: {
        beforeStart: true,
        afterEnd: true,
      },
      draggable: true,
    },
    // {
    //   start: startOfDay(new Date()),
    //   title: 'An event with no end date',
    //   color: colors.yellow,
    //   actions: this.actions,
    // },
    // {
    //   start: subDays(endOfMonth(new Date()), 3),
    //   end: addDays(endOfMonth(new Date()), 3),
    //   title: 'A long event that spans 2 months',
    //   color: colors.blue,
    //   allDay: true,
    // },
    // {
    //   start: addHours(startOfDay(new Date()), 2),
    //   end: addHours(new Date(), 2),
    //   title: 'A draggable and resizable event',
    //   color: colors.yellow,
    //   actions: this.actions,
    //   resizable: {
    //     beforeStart: true,
    //     afterEnd: true,
    //   },
    //   draggable: true,
    // },
  ];

  activeDayIsOpen: boolean = true;

  constructor(
    private modal: NgbModal,
    private bookingService: BookingService,
    private cdr: ChangeDetectorRef,
    private tennisClubService: TennisClubsService,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.cityId = +this.route.snapshot.params.cityId;
    this.tennisClubId = +this.route.snapshot.params.id;
    this.loadEvents();
  }

  loadEvents(): void {
    this.bookingService
      .getBookingsForAClub(this.tennisClubId)
      .subscribe((bookings: any) => {
        console.log(bookings);
        this.events = []; // create a new array here, angular will then be able to pick it up
        for (let booking in bookings) {
          console.log(bookings[booking]['dateStart']);
          this.events.push({
            start: startOfDay(new Date(bookings[booking]['dateStart'])),
            title: 'pulaaaa',
            color: colors.yellowsunflower,
            actions: this.actions,
            allDay: true,
            resizable: {
              beforeStart: true,
              afterEnd: true,
            },
            draggable: true,
          });
          this.events.push({
            start: startOfDay(new Date()),
            end: addDays(new Date(), 1),
            title: 'A 3 day event',
            color: colors.red,
            actions: this.actions,
            allDay: true,
            resizable: {
              beforeStart: true,
              afterEnd: true,
            },
            draggable: true,
          });
        }
      });
  }

  ngAfterViewInit() {
    this.cdr.detectChanges();
    this.setView(this.view);
    console.log(this.allBookings);
    this.setView(this.view);
  }

  ngOnChanges() {
    this.loadEvents();
  }

  setView(view: CalendarView) {
    console.log(this.tennisClubFromDetail);
    this.view = view;
    this.cdr.detectChanges();
    console.log('paaaaulaaa');
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  loadAllBookings(tennisClubId: number) {
    this.bookingService
      .getBookingsForAClub(tennisClubId)
      .subscribe((bookings) => {
        this.allBookings = bookings;
        console.log(this.allBookings);
        this.allBookingsArrive = true;
      });
  }

  // beforeMonthViewRender(renderEvent: CalendarMonthViewBeforeRenderEvent): void {
  //   renderEvent.body.forEach((day) => {
  //     const dayOfMonth = day.date.getDate();
  //     if (dayOfMonth > 5 && dayOfMonth < 10 && day.inMonth) {
  //       day.cssClass = 'bg-pink';
  //     }
  //   });
  // }

  beforeWeekViewRender(renderEvent: CalendarWeekViewBeforeRenderEvent) {
    renderEvent.hourColumns.forEach((hourColumn) => {
      hourColumn.hours.forEach((hour) => {
        hour.segments.forEach((segment) => {
          if (segment.date.getHours() < 28 || segment.date.getHours() > 20) {
            segment.cssClass = 'bg-pink';
          }
        });
      });
    });
  }

  beforeDayViewRender(renderEvent: CalendarDayViewBeforeRenderEvent) {
    renderEvent.hourColumns.forEach((hourColumn) => {
      hourColumn.hours.forEach((hour) => {
        hour.segments.forEach((segment) => {
          if (segment.date.getHours() < 8 || segment.date.getHours() > 22) {
            segment.cssClass = 'bg-pink';
          }
        });
      });
    });
  }

  eventTimesChanged({
    event,
    newStart,
    newEnd,
  }: CalendarEventTimesChangedEvent): void {
    this.events = this.events.map((iEvent) => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd,
        };
      }
      return iEvent;
    });
    this.handleEvent('Dropped or resized', event);
  }

  handleEvent(action: string, event: CalendarEvent): void {
    this.modalData = { event, action };
    this.modal.open(this.modalContent, { size: 'lg' });
  }

  @Output() hourSegmentClicked = new EventEmitter<{
    date: Date;
    sourceEvent: MouseEvent;
  }>();

  addEvent(): void {
    this.events = [
      ...this.events,
      {
        title: 'New event',
        start: startOfDay(new Date()),
        end: endOfDay(new Date()),
        color: colors.red,
        draggable: true,
        resizable: {
          beforeStart: true,
          afterEnd: true,
        },
      },
    ];
  }

  startBooking(event) {
    console.log(typeof event.date.getHours());
    if (event.date.getHours() > 7 && event.date.getHours() < 23) {
      this.viewDate = event.date;
      console.log(this.viewDate);
      this.modal.open(this.modalContent, { size: 'lg' });
    }
  }

  deleteEvent(eventToDelete: CalendarEvent) {
    this.events = this.events.filter((event) => event !== eventToDelete);
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

  close() {
    this.modalReference.close();
  }
}
