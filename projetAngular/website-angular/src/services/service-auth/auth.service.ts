import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {User } from 'src/models/User';
import { DeleteClass } from 'src/models/DeleteClass';
import { Guid } from 'guid-typescript';
import { Stock } from 'src/models/Stock';
import { Address } from 'src/models/Adress';
const AUTH_API = 'https://localhost:7136/api/user/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  _deleteClass : DeleteClass = new DeleteClass('');
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
  
  // deleteAccount(id : string) : Observable<any> {
  //   this._deleteClass.Id = id;
  
  //   return this.http.delete(AUTH_API,this._deleteClass 
  //   );
  // }

  
  updateAccount(_id : Guid,_lastName : string , _firstName :string , _email: string, _password: string,_stocks : Stock[],_addresses :Address[],_siret : string,_phone : string): Observable<any> {
    
     return this.http.post('https://localhost:7136/api/user/', {
       _id,
      _lastName,
      _phone,
       _firstName,
       _email,
      _password,
      _siret,
      _stocks,
      _addresses
     }, httpOptions);
   }
}