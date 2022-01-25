import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DataService } from 'src/services/Data-service/data-service';
import { AuthService } from 'src/services/service-auth/auth.service';
import { User } from 'src/models/User';
import { Guid } from 'guid-typescript';
import {ILogin} from 'src/models/login/i-login';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  isConnected : boolean = false;


  user = new User(Guid.createEmpty(),'','','','','','') || undefined;
  static pathlogin: string = 'login';
  urlLogin: string = '/' + NavbarComponent.pathlogin;
  static pathlogOut: string = 'logout';
  urlLogOut: string = '/' + NavbarComponent.pathlogOut;

  static pathuser: string = 'users';
  urlUser: string = '/' + NavbarComponent.pathuser;


  static pathmarket: string = 'market';
  urlMarket : string = '/' + NavbarComponent.pathmarket;
  
 
  
  static pathregister: string = 'register';
  urlRegister : string = '/' + NavbarComponent.pathregister;

 
  constructor(private router: Router, public auth : AuthService) {

    if(window.sessionStorage.getItem('auth-user')){
       this.isConnected = true;

    
      
       this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);

    }
    
    
   

   }

 
  hideButton(url: string): boolean {
    return this.router.url === url;
  }

  sliceUrl(url: string): string {
    return url.slice(1, url.length);
  }


   static set IsConnected(value : boolean){
    this.IsConnected = value;
  }


}
