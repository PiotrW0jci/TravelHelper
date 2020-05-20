import { Component, OnInit } from '@angular/core';

import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    window.addEventListener('scroll', this.scrollEvent, true);
  }

  scrollEvent = (event: any): void => {
    var header = document.querySelector(".top-bar");
    header.classList.toggle("sticky", window.scrollY > 0)
  }

  logout() {
    this.authenticationService.logout()
  }
}
