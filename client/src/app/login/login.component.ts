import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Input() modalRefFromNavComponent: any;
  model: any = {};

  constructor(public accountService: AccountService, 
    private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/');
    })
  }

  confirm(): void {
    this.modalRefFromNavComponent.hide();
  }
 

}
