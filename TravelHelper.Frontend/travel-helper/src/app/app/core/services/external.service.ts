import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Constants } from 'src/app/config/constants';

@Injectable({
  providedIn: 'root'
})
export class ExternalService {

  constructor(
    private http: HttpClient,
    private constants: Constants
  ) { }

  getLocationDescription(location: String) {
    return this.http.get(this.constants.LOCATION_DESCRIPTION_ENDPOINT(location));
  }

  getLocationCurrenWeather(location: String) {
    return this.http.get(this.constants.WEATHER_ENDPOINT(location));
  }
}
