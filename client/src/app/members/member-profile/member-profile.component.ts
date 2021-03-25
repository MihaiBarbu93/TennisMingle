import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MemberService } from 'src/app/_services/member.service';
import { User } from 'src/app/_models/user';
import { Member } from 'src/app/_models/member';
import { Booking } from 'src/app/_models/booking';


@Component({
  selector: 'app-member-profile',
  templateUrl: './member-profile.component.html',
  styleUrls: ['./member-profile.component.css']
})
export class MemberProfileComponent implements OnInit {
  displayedColumns: string[] = ['dateStart', 'dateEnd', 'tennisClub'];
  user: Member;

  bookings: Booking[] ;
  
  constructor(private memberService: MemberService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMember();
  }


  loadMember() {
    this.memberService.getMember(this.route.snapshot.paramMap.get('username')).subscribe(user => {
      this.user = user;
      this.bookings = user.bookings;
    })
  }

}
