import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Constants } from 'src/app/config/constants';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-budget-planner',
  templateUrl: './budget-planner.component.html',
  styleUrls: ['./budget-planner.component.css']
})
export class BudgetPlannerComponent implements OnInit {
  amount: string;
  description: string;
  all_items: Array<Object>;
  budget_id: number;
  total_budget: number;
  loading = false;
  trip_id;

  constructor(
    private http: HttpClient,
    private constants: Constants,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.trip_id = params['trip_id'];
    })
    this.all_items = [];
    // const httpParams = new HttpParams().set("userId", "  CC56B3A2-AB1F-48FB-8672-239C2CF7E475")
    //this.http.get<any>(`${this.constants.API_ENDPOINT}budget`, httpParams)
    this.loading = true;
    this.http.get(`${this.constants.API_ENDPOINT}budget/${this.trip_id}`)
    .subscribe((items) => {
      console.log(items)
      this.budget_id = items['id'];
      this.all_items = items['itemList']['result'];
      this.loading = false;
      console.log(this.all_items);
    })
  }

  addItem() {
    if (this.amount && this.description) {
      this.http.post<any>(`${this.constants.API_ENDPOINT}budget/addItem`, {
        "budgetPlanId": this.budget_id,
        "name": this.description,
        "value": 1,
        "price": parseInt(this.amount)
       })
      .subscribe(() =>{
        this.all_items.push({
          'name': this.description,
          'value': this.amount,
        })
        this.amount = this.description = '';
      });
    }
  }

  totalExpenses () {
    var total = 0;
    for (let itm of this.all_items) {
      total += itm['value'];
    }
    return total;
  }

  remove(item) {
    console.log(item)
    for (let a of this.all_items) {
      console.log(a['id'] !== item['id'])
    }
    console.log(this.all_items.filter(it => {it['id'] !== item['id']}));
  }

  setTotalAmount() {
    console.log('greh')
    this.http.post(`${this.constants.API_ENDPOINT}budget/amount`, {
      "budgetPlanId": this.budget_id,
      "name": this.total_budget,
     }).subscribe(() => {});
  }
}
