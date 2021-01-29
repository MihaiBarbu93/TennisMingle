import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class DataService {
  private messageSource = new BehaviorSubject('default message');
  currentMessage = this.messageSource.asObservable();

  public http401: BehaviorSubject<boolean>;

  constructor() {
    this.http401 = new BehaviorSubject<boolean>(false);
  }

  changeMessage(message: string) {
    this.messageSource.next(message);
  }
}
