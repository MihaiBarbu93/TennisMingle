import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Input() modalRefFromNavComponent: any;
  model: any = {};
  loginForm =new FormGroup({
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  constructor(public accountService: AccountService, 
    private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl(this.model.username, [
        Validators.required
  
      ]),
      password: new FormControl(this.model.password,[
        Validators.required
      ])

    });
  }
  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/'),
      this.modalRefFromNavComponent.hide();
    })
  }

 

}
