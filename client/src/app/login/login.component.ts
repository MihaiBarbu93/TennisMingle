import { BsModalService } from 'ngx-bootstrap/modal';
import { DataService } from 'src/app/_services/data-service.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  @Input() modalRefFromNavComponent: any;
  model: any = {};
  loginForm: FormGroup;

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService,
    private data: DataService
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  ngAfterViewInit() {
    let logginErrorMessage = document.getElementById('loginErrorMessage');
    this.data.http401.asObservable().subscribe((values) => {
      logginErrorMessage.style.display = 'block';
    });

    logginErrorMessage.style.display = 'none';
    this.modalRefFromNavComponent.onHide.pipe(take(1)).subscribe(() => {
      logginErrorMessage.style.display = 'none';
    });
  }

  get username() {
    return this.loginForm.get('username');
  }
  get password() {
    return this.loginForm.get('password');
  }

  login() {
    if (!this.loginForm.invalid) {
      this.accountService.login(this.model).subscribe((response) => {
        this.router.navigateByUrl('/'), this.modalRefFromNavComponent.hide();
        this.toastr.success("You've successfully login into your account");
      });
    } else {
      this.loginForm.markAllAsTouched();
    }
  }
}
