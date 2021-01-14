import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { User } from '../_models/user';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { UserForRegister } from '../_models/userForRegister';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';
  private currentUserSource: ReplaySubject<User> = new ReplaySubject<User>(1);
  private newUserSource = new ReplaySubject<UserForRegister>(1);
  currentUser$ = this.currentUserSource.asObservable();


  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        console.log(user);
      })
    )
  }

  register(model: any) {
    return this.http.post<UserForRegister>(this.baseUrl + 'account/register', model).pipe(
      map((user: UserForRegister) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.newUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}