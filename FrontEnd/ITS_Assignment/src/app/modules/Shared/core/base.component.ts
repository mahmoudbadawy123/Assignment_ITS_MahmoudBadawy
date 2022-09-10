
import { Component, DoCheck } from "@angular/core";
import { Page } from "src/app/ViewModel/Page";
@Component({
    template: ''
  })
export class BaseComponent implements DoCheck {
    public page = new Page();
    public paginatorEvent: any;
    public rows = [];

    ngDoCheck() {

    }
    constructor() {
        this.page.Filter = '';
        this.page.PageNumber = 0;
        this.page.Size = 5;
        this.page.TotalElements = 0;
    }
} 