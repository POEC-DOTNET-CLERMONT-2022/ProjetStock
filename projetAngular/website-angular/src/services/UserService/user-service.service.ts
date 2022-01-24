import { Injectable } from '@angular/core';
import { User } from 'src/models/User';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { ILogin } from 'src/models/login/i-login';


@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  _baseurl : string  = 'https://localhost:7136/api/User/all';
  constructor(private _httpClient : HttpClient) { }

  getUsers() : Observable<User>{  
    console.log(this._httpClient.get<User>(this._baseurl));
    return this._httpClient.get<User>(this._baseurl);
  }

  getUserById() : Observable<User>{
    return this._httpClient.get<User>(this._baseurl);
  }
 
}
