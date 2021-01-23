import { Component, OnInit, Input } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { UserType } from '../_models/enums/userType';
import { City } from '../_models/city';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UsernameValidator } from '../_validators/username.validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Input() modalRefFromNavComponent: any;
  @Input() dropdownCities!: City[];
  userTypes: any[] = [];
  registerForm = new FormGroup({
    username: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      UsernameValidator.cannotContainSpace,
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
    ]),
    birthDate: new FormControl('', Validators.required),
    role: new FormControl(''),
    city: new FormControl(''),
  });

  configUserType = {
    displayKey: 'description', //if objects array passed which key to be displayed defaults to description
    search: true, //true/false for the search functionlity defaults to false,
    height: 'auto', //height of the list so that if there are more no of items it can show a scroll defaults to auto. With auto height scroll will never appear
    placeholder: 'Select your role', // text to be displayed when no item is selected defaults to Select,
    customComparator: () => {}, // a custom function using which user wants to sort the items. default is undefined and Array.sort() will be used in that case,
    limitTo: 0, // number thats limits the no of options displayed in the UI (if zero, options will not be limited)
    moreText: 'more', // text to be displayed whenmore than one items are selected like Option 1 + 5 more
    noResultsFound: 'No results found!', // text to be displayed when no items are found while searching
    searchPlaceholder: 'Search', // label thats displayed in search input,
    searchOnKey: 'name', // key on which search should be performed this will be selective search. if undefined this will be extensive search on all keys
    clearOnSelection: false, // clears search criteria when an option is selected if set to true, default is false
    inputDirection: 'ltr', // the direction of the search input can be rtl or ltr(default)
  };
  configCities = {
    displayKey: 'name', //if objects array passed which key to be displayed defaults to description
    search: true, //true/false for the search functionlity defaults to false,
    height: 'auto', //height of the list so that if there are more no of items it can show a scroll defaults to auto. With auto height scroll will never appear
    placeholder: 'Select your city', // text to be displayed when no item is selected defaults to Select,
    customComparator: () => {}, // a custom function using which user wants to sort the items. default is undefined and Array.sort() will be used in that case,
    limitTo: 0, // number thats limits the no of options displayed in the UI (if zero, options will not be limited)
    moreText: 'more', // text to be displayed whenmore than one items are selected like Option 1 + 5 more
    noResultsFound: 'No results found!', // text to be displayed when no items are found while searching
    searchPlaceholder: 'Search', // label thats displayed in search input,
    searchOnKey: 'name', // key on which search should be performed this will be selective search. if undefined this will be extensive search on all keys
    clearOnSelection: false, // clears search criteria when an option is selected if set to true, default is false
    inputDirection: 'ltr', // the direction of the search input can be rtl or ltr(default)
  };

  constructor(
    private accountService: AccountService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getUserTypes();
    this.registerForm = new FormGroup({
      username: new FormControl(this.model.username, [
        Validators.required,
        Validators.minLength(8),
        UsernameValidator.cannotContainSpace,
      ]),
      password: new FormControl(this.model.password, [
        Validators.required,
        Validators.minLength(8),
      ]),
      birthDate: new FormControl(this.model.birthDate, [
        Validators.required,
        Validators.minLength(5),
      ]),
      role: new FormControl(this.model.role),
      city: new FormControl(this.model.city),
    });
  }

  get username() {
    return this.registerForm.get('username');
  }
  get password() {
    return this.registerForm.get('password');
  }
  get birthDate() {
    return this.registerForm.get('birthDate');
  }
  get role() {
    return this.registerForm.get('role');
  }
  get city() {
    return this.registerForm.get('city');
  }

  get f() {
    return this.registerForm.controls;
  }

  getUserTypes() {
    for (var n in UserType) {
      if (typeof UserType[n] === 'number') this.userTypes.push(n);
    }
  }

  // getCitiesNames(){
  //   this.dropdownCities.forEach( (c) => {
  //     this.citiesForRegister.push(c.name);
  // });
  // }

  register() {
    this.accountService.register(this.model).subscribe(
      (response) => {
        console.log(response), this.modalRefFromNavComponent.hide();
        this.toastr.success('Account created successfully');
      },
      (error) => {
        console.log(error);
        this.toastr.error(error.error);
      }
    );
  }
}
