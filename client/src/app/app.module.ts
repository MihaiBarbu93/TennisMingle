import { DataService } from './_services/data-service.service';
import { SharedModule } from './_modules/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import {
  FormsModule,
  NgControl,
  ReactiveFormsModule,
  FormControl,
} from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { TennisClubListComponent } from './tennis-club/tennis-club-list/tennis-club-list.component';
import { TennisClubDetailComponent } from './tennis-club/tennis-club-detail/tennis-club-detail.component';
import { TennisClubCardComponent } from './tennis-club/tennis-club-card/tennis-club-card.component';
import { FooterComponent } from './footer/footer.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RegisterComponent } from './register/register.component';
import { ToastrModule } from 'ngx-toastr';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ModalModule } from 'ngx-bootstrap/modal';
import { LoginComponent } from './login/login.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxSelectModule } from 'ngx-select-ex';
import { SelectDropDownModule } from 'ngx-select-dropdown';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    TennisClubListComponent,
    TennisClubDetailComponent,
    TennisClubCardComponent,
    FooterComponent,
    RegisterComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    FormsModule,
    SharedModule,
    FontAwesomeModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    NgxSelectModule,
    ModalModule.forRoot(),
    ReactiveFormsModule,
    SelectDropDownModule
  ],
  providers: [BsModalService, DataService],
  bootstrap: [AppComponent],
})
export class AppModule {}
