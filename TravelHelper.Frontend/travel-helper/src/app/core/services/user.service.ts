import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from 'src/app/shared/models/user';
import { Constants } from 'src/app/config/constants';


@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(
      private http: HttpClient,
      private constants: Constants
    ) { }

    register(user: User) {
        return this.http.post(`${this.constants.API_ENDPOINT}users/register`, user);
    }

    addTrip(tripName: object) {
      return this.http.post(`${this.constants.API_ENDPOINT}trip/add`, tripName)
    }

    getUserTrips() {
      return this.http.get(`${this.constants.API_ENDPOINT}trip`)
    }

    removeTrip(id) {
      return this.http.post(`${this.constants.API_ENDPOINT}trip/delete`, id)
    }
}
