import { Component, OnInit } from '@angular/core';
import { ExternalService } from 'src/app/core/services/external.service';
import { ActivatedRoute } from '@angular/router';
import { withLatestFrom } from 'rxjs/operators';
import { UserService } from 'src/app/core/services/user.service';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {
  description: string;
  location: string;

  showFlights: boolean;
  showHotels: boolean;

  ph1: string;
  ph2: string;
  weatherData: any;
  popupIsActive: boolean;
  addNewTravelClicked: boolean;
  loading = true;
  constructor(
    private route: ActivatedRoute,
    private externalService: ExternalService,
    private userService: UserService,
    public authService: AuthenticationService,
  ) { }

  ngOnInit(): void {
    console.log('HKHHHHHHHHHHH')
    this.popupIsActive = this.addNewTravelClicked = false;
    this.showFlights = this.showHotels = false;
    this.ph1 = localStorage.getItem('ph1');
    this.ph2 = localStorage.getItem('ph2');
    this.route.params.subscribe(params => {
      this.location = params['location'];
      this.externalService.getLocationDescription(this.location)
      .subscribe(data => {
        console.log('beg')
        let locationData = data['query']['pages'][Object.keys(data['query']['pages'])[0]];
        this.description = locationData['extract'];
        this.externalService.getLocationCurrenWeather(this.location)
        .subscribe(data => {
          this.weatherData= {
            mainWeather: data['weather'][0]['main'],
            temp: data['main']['temp'],
            feelsLike: data['main']['feels_like'],
            icon: data['weather'][0]['icon']
          }
          this.loading = false;
          console.log('dskjfkj')
        });
      })
    });
  }

  addLocationToTravel(trip) {
    console.log(trip);
    this.popupIsActive = false;
  }

  addNewTravel(travelName: string) {
    this.addNewTravelClicked = true;
    if (!travelName.length) {
      return
    }
    this.userService.addTrip(
      { 'name': travelName,
       'location': this.location,
        'link': this.ph1 }
    ).subscribe(data => {
      this.popupIsActive = false;
    })
  }
}
