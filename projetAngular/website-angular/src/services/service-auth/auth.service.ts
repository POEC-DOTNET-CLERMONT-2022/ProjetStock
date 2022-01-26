import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {User } from 'src/models/User';
const AUTH_API = 'https://localhost:7136/api/user/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  isLog : boolean = false;
  constructor(private http: HttpClient) {
  
   }


  isloggedIn() :boolean {
    return this.isLog;
  }

  setIsLog(value : boolean) : void{
     this.isLog = value;
  }

  login(_email: string, _password: string): Observable<any> {
     
     return this.http.post(AUTH_API +'authenticate', {
      _email,
      _password
    }, httpOptions);
  }
  

  register(_lastName : string , _firstName :string , _email: string, _password: string): Observable<any> {
    
    return this.http.post('https://localhost:7136/api/user/register', {
      _lastName,
      _firstName,
      _email,
      _password
    }, httpOptions);
  }


  generateApiKey(_email : string, _password : string): Observable<any> {
    
    return this.http.post(AUTH_API + 'authenticate', {
      _email,
      _password
    }, httpOptions);
  }
  // updateAccount(user : User): Observable<any> {
    
  //   return this.http.post('https://localhost:7136/api/user/register', {
  //     user._id,
  //    _lastName,
  //     _firstName,
  //     _email,
  //     _password
  //   }, httpOptions);
  // }
}