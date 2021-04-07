import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MembersService } from 'src/app/_services/members.service';
import { User } from 'src/app/_models/user';
import { Member } from 'src/app/_models/member';
import { Booking } from 'src/app/_models/booking';
import { AccountService } from 'src/app/_services/account.service';
import { take } from 'rxjs/operators';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-member-profile',
  templateUrl: './member-profile.component.html',
  styleUrls: ['./member-profile.component.css']
})
export class MemberProfileComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  displayedColumns: string[] = ['dateStart', 'dateEnd', 'tennisClub'];
  currentDate = new Date();
  newDateNr : number;
  member: Member;
  user: User;
  bookings: number[] = [];
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  
  constructor(private membersService: MembersService, private route: ActivatedRoute,public accountService: AccountService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.newDateNr = this.currentDate.getTime()
    this.loadMember();
  }


  loadMember() {
    this.membersService.getMember(this.user.userName).subscribe(member => {
      this.member = member;
      this.loadBookings(member);
    })
  }

  loadBookings(member: Member){
    member.bookings.forEach(booking => {
      let dateStart = new Date(booking.dateStart);
      this.bookings.push(dateStart.getTime())
    });
  }
}


