import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppConfigService } from 'src/app/Services/AppConfig.service';

@Injectable()
export class ApiService  implements OnInit{
// private url: string = "https://jsonplaceholder.typicode.com/";
 private url: string = "";


public headers = new HttpHeaders();
constructor(private http: HttpClient, private router: Router
) {


  if (!AppConfigService.settings.apiServer.usingInternalApi){
    this.url = AppConfigService.settings.apiServer.url;
  }
  else{
    this.url = window.location.href.split('#')[0] + '/api/';
    console.log(this.url);
  }
}

ngOnInit() {

}



geturl(){
  return this.url
}
// get(action: String) {
  
//   return this.http.get(this.url + action, {
//     headers: this.headers
//   }).pipe();
// }

// post(action: String, paramters: any) {
//   return this.http.post(this.url + action, paramters,{
//     headers: this.headers
//   }).pipe();
// }

// put(action: string, paratmers: any) {
//   return this.http.put(this.url + action, paratmers,{
//     headers: this.headers
//   }).pipe();
// }

// delete(action: String) {
//   return this.http.delete(this.url + action,{
//     headers: this.headers
//   }).pipe();
// }



getNoToken(action: String) {
  
  return this.http.get(this.url + action).pipe();
}

postNoToken(action: String, paramters: any) {
  return this.http.post(this.url + action, paramters).pipe();
}

putNoToken(action: string, paratmers: any) {
  return this.http.put(this.url + action, paratmers).pipe();
}

deleteNoToken(action: String) {
  return this.http.delete(this.url + action).pipe();
}



}

