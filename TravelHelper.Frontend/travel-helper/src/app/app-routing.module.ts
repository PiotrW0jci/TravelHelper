import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TopDestinationsComponent } from './shared/components/top-destinations/top-destinations.component';
import { RegistrationComponent } from './shared/components/registration/registration.component';
import { LoginComponent } from './shared/components/login/login.component';
import { FindLocationComponent } from './shared/components/find-location/find-location.component';


const routes: Routes = [
  { path: '', component: TopDestinationsComponent},
  { path: 'registration', component: RegistrationComponent},
  { path: 'login', component: LoginComponent},
  { path: 'locations', component: FindLocationComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
