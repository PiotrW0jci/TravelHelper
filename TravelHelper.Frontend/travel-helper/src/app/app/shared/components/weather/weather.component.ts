import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  @Input() temp: string;
  @Input() icon: string;
  @Input('main-weather') mainWeather: string;
  @Input('feels-like') feelsLike: string;

  constructor() {
  }

  ngOnInit(): void {
  }

}
