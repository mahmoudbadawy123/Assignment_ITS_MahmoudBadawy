import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  AbstractControl,
  Validators,
  FormControl,
} from '@angular/forms';
import { BaseComponent } from './modules/Shared/core/base.component';
import { ApiService } from './modules/Shared/Shared-Services/http/Api.service';
import { ValidPatterns } from './modules/Shared/Vlidation-Patterns/Valid-Patterns';
import { CustomersWithPaging } from './ViewModel/CustomersWithPaging';
import { Page } from './ViewModel/Page';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent extends BaseComponent implements OnInit {
  title = 'ITS_Assignment';

  private _formBuilder: any;
  MyForm: FormGroup;
  get form(): { [key: string]: AbstractControl } {
    return this.MyForm.controls;
  }

  row: Array<any> = [];


  public displayedColumns = [
    'id',
    'customerName',
    'class',
    'phone',
    'email',
    'comment',
    // 'Edit',
    // 'select',
  ];

   Mypage = new Page();
  constructor(private api: ApiService) {
    super();
    this.getItems();
    this.MyForm = new FormGroup({
      ID: new FormControl(''),
      CustomerName: new FormControl('', [
        Validators.required,
        Validators.pattern(ValidPatterns.WORDS_AE_ONLY),
      ]),
      Class: new FormControl('', [
        Validators.required,
        Validators.pattern(ValidPatterns.ONE_AE_AlPHAB),
      ]),
      Phone: new FormControl('', [
        Validators.required,
        Validators.pattern(ValidPatterns.MOBILE),
      ]),
      Email: new FormControl('', [Validators.required, Validators.email]),
      Comment: new FormControl(''),
    });
  }
  ngOnInit(): void {
    
  }

  Data: CustomersWithPaging = new CustomersWithPaging();
  Add() {

    this.api.postNoToken('Customer/Add', this.MyForm.value).subscribe(
      (res: any) => {
        console.log(res);
        this.getItems();
      },
      (error) => {
     
      }
    );

  }
  Update() {

    this.api.postNoToken('Customer/Update', this.MyForm.value).subscribe(
      (res: any) => {
        console.log(res);
        this.getItems();
      },
      (error) => {
     
      }
    );
  }
  Delete() {
    this.api.postNoToken('Customer/Delete', this.MyForm.value).subscribe(
      (res: any) => {
        console.log(res);
        this.getItems();
      },
      (error) => {
     
      }
    );

  }
  getItems() {
    this.api.postNoToken('Customer/GetAll', this.Mypage).subscribe(
      (res: any) => {
        this.Data = res;
        if (this.Data) {
          this.row = this.Data.data;
          if (this.row.length > 0) {
            this.Mypage = this.Data.page;
            console.log(this.Mypage);
          }
        }
      },
      (error) => {
     
      }
    );
  }
 
  Clear() {
    this.MyForm.reset();
    this.OnSelectMode = false;
  }
  getServerData(event: any) {
    this.Mypage.PageNumber = event.pageIndex;
    this.Mypage.Size = event.pageSize;
    this.getItems();
  }



  SortDataID:any = "" ;
  SortDatacustomerName:any = "" ;
  SortDataclass:any = "" ;
  SortDataphone:any = "" ;
  SortDataemail:any = "" ;
  SortDatacomment:any = "" ;
  onSort(sortInfo: any) {
    debugger;
    this.Mypage.PageNumber = 0;
    this.Mypage.OrderBy = sortInfo.active + sortInfo.direction;
    console.log(this.Mypage.OrderBy);
    if(this.Mypage.OrderBy == "idasc" )
    {
      this.SortDataID = " (A-Z) "
    }
    else if (this.Mypage.OrderBy == "iddesc"){
      this.SortDataID = " (Z-A) "
    }
    else {
      this.SortDataID = "";
    }



    // 'comment',


    if(this.Mypage.OrderBy == "commentasc" )
    {
      this.SortDatacomment = " (A-Z) "
    }
    else if (this.Mypage.OrderBy == "commentdesc"){
      this.SortDatacomment = " (Z-A) "
    }
    else {
      this.SortDatacomment = "";
    }



    if(this.Mypage.OrderBy == "emailasc" )
    {
      this.SortDataemail = " (A-Z) "
    }
    else if (this.Mypage.OrderBy == "emaildesc"){
      this.SortDataemail = " (Z-A) "
    }
    else {
      this.SortDataemail = "";
    }




    if(this.Mypage.OrderBy == "phoneasc" )
    {
      this.SortDataphone = " (A-Z) "
    }
    else if (this.Mypage.OrderBy == "phonedesc"){
      this.SortDataphone = " (Z-A) "
    }
    else {
      this.SortDataphone = "";
    }



    if(this.Mypage.OrderBy == "classasc" )
    {
      this.SortDataclass = " (A-Z) "
    }
    else if (this.Mypage.OrderBy == "classdesc"){
      this.SortDataclass = " (Z-A) "
    }
    else {
      this.SortDataclass = "";
    }



    if(this.Mypage.OrderBy == "customerNameasc" )
    {
      this.SortDatacustomerName = " (A-Z) "
    }
    else if (this.Mypage.OrderBy == "customerNamedesc"){
      this.SortDatacustomerName = " (Z-A) "
    }
    else {
      this.SortDatacustomerName = "";
    }


    this.getItems();
  }


  OnSelectMode = false;
  showSelect(item: any) {
    debugger;
    console.log(item);
    this.OnSelectMode = true;
    console.log(this.OnSelectMode);
    this.form['ID'].setValue(item.id);
    this.form['CustomerName'].setValue(item.customerName);
    this.form['Class'].setValue(item.class);
    this.form['Phone'].setValue(item.phone);
    this.form['Email'].setValue(item.email);
    this.form['Comment'].setValue(item.comment);
  }
}
