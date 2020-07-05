import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { TopDestinationsComponent } from './shared/components/top-destinations/top-destinations.component';
import { RecommendedPlacesComponent } from './shared/components/recommended-places/recommended-places.component';
import { RegistrationComponent } from './shared/components/registration/registration.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginComponent } from './shared/components/login/login.component';
import { SearchComponent } from './shared/components/search/search.component';
import { FindLocationComponent } from './shared/components/find-location/find-location.component';
import { BudgetPlannerComponent } from './shared/components/budget-planner/budget-planner.component';
import { LocationComponent } from './shared/components/location/location.component';
import { WeatherComponent } from './shared/components/weather/weather.component';
import { TripsComponent } from './shared/components/trips/trips.component';
import { JwtInterceptor } from './shared/helpers/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TopDestinationsComponent,
    RecommendedPlacesComponent,
    RegistrationComponent,
    LoginComponent,
    SearchComponent,
    FindLocationComponent,
    BudgetPlannerComponent,
    LocationComponent,
    WeatherComponent,
    TripsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
