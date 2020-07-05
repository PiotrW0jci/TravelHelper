import { Component, OnInit } from '@angular/core';

import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {
  trips: Array<number>;
  constructor(
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.trips = [1, 2];
    this.userService.getUserTrips().subscribe(resp => { console.log(resp)})
  }

}
