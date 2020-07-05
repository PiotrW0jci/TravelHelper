import { Component, OnInit, EventEmitter, Output, Input, ViewChild } from '@angular/core';
import { } from 'googlemaps';
import { Router } from '@angular/router';
import { Photos } from 'src/app/config/tnl';

@Component({
  selector: 'app-top-destinations',
  templateUrl: './top-destinations.component.html',
  styleUrls: ['./top-destinations.component.css']
})
export class TopDestinationsComponent implements OnInit {
  @Input() adressType: string;
  @ViewChild('addresstext') addresstext: any;

  autocompleteInput: string;
  queryWait: boolean;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
    this.getPlaceAutocomplete();
  }

  private getPlaceAutocomplete() {
    const autocomplete = new google.maps.places.Autocomplete(this.addresstext.nativeElement,
        {
            types: ['geocode']
        });
    google.maps.event.addListener(autocomplete, 'place_changed', () => {
        const place = autocomplete.getPlace();
        this.invokeEvent(place);
    });
  }

  invokeEvent(place: Object) {
    localStorage.setItem('ph1', place['photos'][0].getUrl());
    localStorage.setItem('ph2', place['photos'][1].getUrl());
    this.router.navigate(['/locations/' + place['name']]);
  }
}
