import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Constants } from 'src/app/config/constants';

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

  constructor(
    private http: HttpClient,
    private constants: Constants
  ) { }

  ngOnInit(): void {
    this.all_items = [];
    this.total_budget = 4300.00;
    // const httpParams = new HttpParams().set("userId", "  CC56B3A2-AB1F-48FB-8672-239C2CF7E475")
    //this.http.get<any>(`${this.constants.API_ENDPOINT}budget`, httpParams)
    this.loading = true;
    this.http.get(`${this.constants.API_ENDPOINT}budget/CC56B3A2-AB1F-48FB-8672-239C2CF7E475`)
    .subscribe((items) => {
      this.budget_id = items['itemList']['result'][0]['budgetPlanId'];
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
}
