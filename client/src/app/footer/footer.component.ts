import { Component, OnInit } from '@angular/core';
import {
  faFacebook,
  faInstagram,
  faLinkedin,
  faTwitter,
} from '@fortawesome/free-brands-svg-icons';
import {
  faFax,
  faHome,
  faInfoCircle,
  faPhoneSquare,
} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css'],
})
export class FooterComponent implements OnInit {
  faFacebook = faFacebook;
  faInstagram = faInstagram;
  faTwitter = faTwitter;
  faLinkedin = faLinkedin;
  faHome = faHome;
  faInfo = faInfoCircle;
  faPhone = faPhoneSquare;
  faFax = faFax;
  constructor() {}

  ngOnInit(): void {}
}
