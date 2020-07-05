import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TopDestinationsComponent } from './shared/components/top-destinations/top-destinations.component';
import { RegistrationComponent } from './shared/components/registration/registration.component';
import { LoginComponent } from './shared/components/login/login.component';
import { FindLocationComponent } from './shared/components/find-location/find-location.component';
import { BudgetPlannerComponent } from './shared/components/budget-planner/budget-planner.component';
import { LocationComponent } from './shared/components/location/location.component';
import { OuterCardComponent } from './shared/components/outer-card/outer-card.component';
import { WeatherComponent } from './shared/components/weather/weather.component';
import { TripsComponent } from './shared/components/trips/trips.component';

const routes: Routes = [
  { path: '', component: TopDestinationsComponent},
  { path: 'registration', component: RegistrationComponent},
  { path: 'login', component: LoginComponent},
  { path: 'locations', component: FindLocationComponent},
  { path: 'budget', component: BudgetPlannerComponent},
  { path: 'locations/:location', component: LocationComponent},
  { path: 'outer', component: OuterCardComponent},
  { path: 'weather', component: WeatherComponent},
  { path: 'trips', component: TripsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
