import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './modules/Shared/Shared.module';
import { AppConfigService } from './Services/AppConfig.service';

export function initializeApp(appConfig: AppConfigService) {
  return () => appConfig.load();
}

var Modules : any[]= [
  BrowserModule,
  AppRoutingModule,
  BrowserAnimationsModule,
  FormsModule,
  ReactiveFormsModule,
  HttpClientModule,
  SharedModule,
  
]

let Components : any[]= [
  AppComponent
]

let Services : any[]= [
 
  AppConfigService,
  {
    provide: APP_INITIALIZER,
    useFactory: initializeApp,
    deps: [AppConfigService], multi: true
  }


]

let Pipes= [

]


@NgModule({
  declarations: [
    ...Components,
  ],
  imports: [
    ...Modules,
  ],
  providers: [...Services
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
