import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Constants {
    public readonly API_ENDPOINT: string = 'https://localhost:5001/';
    public readonly LOCATION_DESCRIPTION_ENDPOINT = (titles) => `https://en.wikivoyage.org//w/api.php?action=query&format=json&prop=extracts&titles=${titles}&exsentences=4&origin=*`;
    public readonly WEATHER_ENDPOINT = (location) => `https://api.openweathermap.org/data/2.5/weather?q=${location}&units=metric&appid=d4af3e33095b8c43f1a6815954face64`
}
