import { Injectable } from '@angular/core';
import { User } from 'src/models/User';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { ILogin } from 'src/models/login/i-login';
import { Order } from 'src/models/Order';
import { Market } from 'src/models/Market';
@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  _baseurl : string  = 'https://localhost:7136/api/User/all';
  _baseUrlUserById : string = 'https://localhost:7136/api/User?id='
  _base_url_order :string = 'https://localhost:7136/api/Order/all';
  _baseurl_market :string = 'https://localhost:7136/api/Market/all';
  constructor(private _httpClient : HttpClient) { }

  getUsers() : Observable<User[]>{  
    return this._httpClient.get<User[]>(this._baseurl);
  }

  getOrders() : Observable<Order[]>{  
    return this._httpClient.get<Order[]>(this._base_url_order);
  }
  getMarkets() : Observable<Market[]>{  
    return this._httpClient.get<Market[]>(this._baseurl_market);
  }
  getUserById(id : string ) : Observable<User[]>{

    return this._httpClient.get<User[]>(this._baseUrlUserById + id);
  }
 
}
