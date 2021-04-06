import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MembersService } from 'src/app/_services/members.service';
import { User } from 'src/app/_models/user';
import { Member } from 'src/app/_models/member';
import { Booking } from 'src/app/_models/booking';
import { AccountService } from 'src/app/_services/account.service';
import { take } from 'rxjs/operators';


@Component({
  selector: 'app-member-profile',
  templateUrl: './member-profile.component.html',
  styleUrls: ['./member-profile.component.css']
})
export class MemberProfileComponent implements OnInit {
  displayedColumns: string[] = ['dateStart', 'dateEnd', 'tennisClub'];
  member: Member;
  user: User;
  
  constructor(private membersService: MembersService, private route: ActivatedRoute,public accountService: AccountService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadMember();
  }


  loadMember() {
    this.membersService.getMember(this.user.userName).subscribe(member => {
      this.member = member;
    })
  }
}


