import { DataService } from './_services/data-service.service';
import { SharedModule } from './_modules/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { AgmCoreModule } from '@agm/core';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/has-role.directive';
import { UserManagementComponent } from './admin/user-management/user-management.component';

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
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserManagementComponent,
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
    SelectDropDownModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAHkvce8fYg5UNgF_Xkp1alX_2EIxtNQJo'
    })
  ],
  providers: [
    BsModalService,
     DataService,
     {provide: HTTP_INTERCEPTORS, useClass:ErrorInterceptor, multi: true}
    ],
  bootstrap: [AppComponent],
})
export class AppModule {}
