import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar/navbar.component';
import { FormGroup, FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { UserComponentComponent } from './users/user-component/user-component.component';

import {HttpClientModule} from "@angular/common/http";

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { DataService } from 'src/services/Data-service/data-service';
import { LogoutComponent } from './logout/logout.component';
import { RegisterComponent } from './register/register.component';
import { ProfilComponentComponent } from './profil/profil-component/profil-component.component';
import { ApiComponent } from './api/api.component';
import { UserDeleteComponent } from './users/user-delete/user-delete/user-delete.component';
import { UserModifyComponent } from './users/user-modify/user-modify/user-modify.component';
import { UserAddComponent } from './users/user-add/user-add/user-add.component';
import { OrdersComponent } from './orders/orders.component';
import { MarketsComponent } from './markets/markets.component';
import { MarketAddComponent } from './markets/market-add/market-add.component';
import { MarketUpdateComponent } from './markets/market-update/market-update.component';
import { MarketDeleteComponent } from './markets/market-delete/market-delete.component';
import { OrdersModifyComponent } from './orders/orders-modify/orders-modify.component';
import { NotifsComponentComponent } from './notifs/notifs-component/notifs-component.component';
import { NotifsAddComponent } from './notifs/notifs-add/notifs-add.component';
import { NotifsModifyComponent } from './notifs/notifs-modify/notifs-modify.component';
@NgModule({
  
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,

    
    UserComponentComponent,
          LogoutComponent,
          RegisterComponent,
          ProfilComponentComponent,
          ApiComponent,
          UserDeleteComponent,
          UserModifyComponent,
          UserAddComponent,
          OrdersComponent,
          MarketsComponent,
          MarketAddComponent,
          MarketUpdateComponent,
          MarketDeleteComponent,
          OrdersModifyComponent,
          NotifsComponentComponent,
          NotifsAddComponent,
          NotifsModifyComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
 


  ],
providers: [DataService],
bootstrap: [AppComponent]
})
export class AppModule { }
