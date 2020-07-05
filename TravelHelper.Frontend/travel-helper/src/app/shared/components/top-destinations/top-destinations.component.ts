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

  handleBarcelona() {
    localStorage.setItem('ph1', "https://lh3.googleusercontent.com/p/AF1QipNUDbk04KIHy9glMyjNT5LNsDXFCWYGiZKCtD9C=s1600-w3024");
    localStorage.setItem('ph2', "https://lh3.googleusercontent.com/p/AF1QipPttp0i-yn59xb66iPYzJwo-75Wpjn2ShnoVJuy=s1600-w800");
  }

  handleMaledives() {
    localStorage.setItem('ph1', "https://www.questor-travel.co.uk/wp-content/uploads/maldives-water-villas-1800x2250.jpg");
    localStorage.setItem('ph2', "https://travelhero.pl/wp-content/uploads/2018/02/malediwy.jpg");
  }

  handleGrand() {
    localStorage.setItem('ph2', "https://i.pinimg.com/736x/23/2b/71/232b71e4f924a44e4edca33efb86473a.jpg");
    localStorage.setItem('ph1', "https://s27135.pcdn.co/wp-content/uploads/2019/06/Grand-Canyon-National-Park.jpg.optimal.jpg");
  }
}
