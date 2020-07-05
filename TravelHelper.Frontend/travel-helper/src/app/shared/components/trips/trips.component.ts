import { Component, OnInit } from '@angular/core';

import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {
  trips;
  constructor(
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.userService.getUserTrips().subscribe(resp => { this.trips = resp['trip_list']; console.log(this.trips) })
  }

  removeTrip(tripId) {
    console.log(tripId)
    this.userService.removeTrip(
      { 'TripId': tripId }).subscribe(resp => { this.userService.getUserTrips().subscribe(resp => {this.trips = resp['trip_list']})})
  }
}
