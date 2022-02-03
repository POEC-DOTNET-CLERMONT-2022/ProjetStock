import { Injectable } from '@angular/core';
import { User } from 'src/models/User';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { ILogin } from 'src/models/login/i-login';
import { Order } from 'src/models/Order';
import { Market } from 'src/models/Market';
import { Notification } from 'src/models/Notification';
import { Stock } from 'src/models/Stock';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  _baseurl : string  = 'https://localhost:7136/api/User/all';
  _baseUrlUserById : string = 'https://localhost:7136/api/User?id='
  _base_url_order :string = 'https://localhost:7136/api/Order/all';
  _baseurl_market :string = 'https://localhost:7136/api/Market/all';
  _vase_url :string = 'https://localhost:7136/api/Notification/all';
  _user_token : string ='';
  
  constructor(private _httpClient : HttpClient) {

   
   }

  getUsers() : Observable<User[]>{ 
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ this._user_token
   });
    return this._httpClient.get<User[]>(this._baseurl, { headers: reqHeader});
  }
  
  getNotifs() : Observable<Notification[]>{  
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ this._user_token
   });
    return this._httpClient.get<Notification[]>(this._vase_url, {headers : reqHeader})!;
  }

  getOrders() : Observable<Order[]>{  
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this._httpClient.get<Order[]>(this._base_url_order, {headers : reqHeader});
  }
  getMarkets() : Observable<Market[]>{ 
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ this._user_token
   }); 
    return this._httpClient.get<Market[]>(this._baseurl_market, {headers :reqHeader});
  }

  getStocks() : Observable<Stock[]>{  
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ this._user_token
   });
    return this._httpClient.get<Stock[]>('https://localhost:7136/api/stocks/all',{headers: reqHeader});
  }
  getUserById(id : string ) : Observable<User[]>{
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ this._user_token
   });
    return this._httpClient.get<User[]>(this._baseUrlUserById + id, {headers :reqHeader});
  }
 
}
