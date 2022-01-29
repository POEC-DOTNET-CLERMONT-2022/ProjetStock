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
  user_email : string = '';
  
  user = new User(Guid.createEmpty(),'','','','','','') || undefined;

  static pathModStock: string = 'modify_stock';
  urlModStock : string = '/' + NavbarComponent.pathModStock;
  

  static pathStockAdd: string = 'ajout_stocks';
  urlAjoutStock : string = '/' + NavbarComponent.pathStockAdd;
  static pathSupStock: string = 'delete_stock';
  urlSupStock : string = '/' + NavbarComponent.pathSupStock;
    

  static pathStock: string = 'stocks';
  urlStock: string = '/' + NavbarComponent.pathStock;

  static pathlogin: string = 'login';
  urlLogin: string = '/' + NavbarComponent.pathlogin;
  static pathlogOut: string = 'logout';
  urlLogOut: string = '/' + NavbarComponent.pathlogOut;

  static pathApi: string = 'api';
  urlApi: string = '/' + NavbarComponent.pathApi;
  static pathNotifs: string = 'notifs';
  urlNotifs: string = '/' + NavbarComponent.pathNotifs;

  static pathuser: string = 'users';
  urlUser: string = '/' + NavbarComponent.pathuser;

  static pathOrders: string = 'orders';
  urlOrders: string = '/' + NavbarComponent.pathOrders;

  static pathmarket: string = 'market';
  urlMarket : string = '/' + NavbarComponent.pathmarket;
  
  static pathAjoutNotifs: string = 'ajout_notif';
  urlAjoutNotifs : string = '/' + NavbarComponent.pathAjoutNotifs;

  static pathModifNotif: string = 'modify_notifs';
  urlNotif : string = '/' + NavbarComponent.pathModifNotif+ '/:id';

  static pathModifUsers: string = 'modify_user';
  urlModif : string = '/' + NavbarComponent.pathModifUsers+ '/:id';

  static pathModifOrder: string = 'modify_order';
  urlOrder : string = '/' + NavbarComponent.pathModifOrder+ '/:id';
 
  static pathUpdateMarket: string = 'modifier_market';
  urlUpdateMarket : string = '/' + NavbarComponent.pathUpdateMarket + '/:id';


  static pathAjoutUser: string = 'ajout_user';
  urlAjoutUser : string = '/' + NavbarComponent.pathAjoutUser;

  static pathAjoutMarket: string = 'ajout_market';
  urlAjoutMarket : string = '/' + NavbarComponent.pathAjoutMarket;

  
  static pathProfile: string = 'profile';
  urlProfile : string = '/' + NavbarComponent.pathProfile;
  
  
  static pathregister: string = 'register';
  urlRegister : string = '/' + NavbarComponent.pathregister;

  static pathSupNotif: string = 'delete_notifs';
  urlSupNotif : string = '/' + NavbarComponent.pathSupNotif+ '/:id';
 
  static pathDeleteMarket: string = 'delete_market';
  urlDeleteMarket : string = '/' + NavbarComponent.pathDeleteMarket;

  static pathSupUser: string = 'delete_user';
  urlSupUser : string = '/' + NavbarComponent.pathSupUser;

  static pathSupOrder: string = 'delete_order';
  urlSupOrder : string = '/' + NavbarComponent.pathSupOrder;
  
  
  constructor(private router: Router, public auth : AuthService) {

    if(window.sessionStorage.getItem('auth-user')){
       this.isConnected = true;

    
     
   
       this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
    
       var json = JSON.stringify(this.user)
      

       var data =json.split(':');
      

      

      
       
       this.user_email  = data[3].split(',')[0];

 
   
     
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
