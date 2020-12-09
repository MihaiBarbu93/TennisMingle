import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Tennis Mingle';
  cities: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCities();
  }

  getCities() {
    this.http.get('https://localhost:5001/api/cities').subscribe(
      (response) => {
        console.log(response);
        this.cities = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
