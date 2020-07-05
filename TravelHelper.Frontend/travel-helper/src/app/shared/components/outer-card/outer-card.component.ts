import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-outer-card',
  templateUrl: './outer-card.component.html',
  styleUrls: ['./outer-card.component.css']
})
export class OuterCardComponent implements OnInit {
  years: Array<Number>;
  months: Array<String>;

  constructor() { }


  ngOnInit(): void {
    this.years = [2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027];
    this.months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dev'];
  }

}
