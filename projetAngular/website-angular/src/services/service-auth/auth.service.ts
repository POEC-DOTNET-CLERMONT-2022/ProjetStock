import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {User } from 'src/models/User';
import { DeleteClass } from 'src/models/DeleteClass';
import { Guid } from 'guid-typescript';
import { Stock } from 'src/models/Stock';
import { Address } from 'src/models/Adress';
import { Market } from 'src/models/Market';
import { Order} from 'src/models/Order';
import { Notification } from 'src/models/Notification';

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

  
  updateAccount(_id : Guid,_lastName : string , _firstName :string , _email: string, _password: string,_stocks : Stock[],_addresses :Address[],_siret : string,_phone : string, _token: string,_expireDate : Date): Observable<any> {
    
     return this.http.put('https://localhost:7136/api/user/', {
      '_id' :_id.toString(),
      '_lastName' : _lastName,  
       '_firstName' :_firstName,
       '_email' :_email,
       '_phone' :_phone,
      '_siret' :  _siret,
      '_password' : _password,
      '_token' :_token,
     '_expireDate' : _expireDate,
      '_stocks' : _stocks,
      '_addresses' :    _addresses
     }, httpOptions);
   }

   addAccount(_id : Guid,_lastName : string , _firstName :string , _email: string, _password: string,_stocks : Stock[],_addresses :Address[],_siret : string,_phone : string, _token: string,_expireDate : Date): Observable<any> {
    
    return this.http.post('https://localhost:7136/api/user/', {
      '_id' :_id.toString(),
     '_lastName' : _lastName,  
      '_firstName' :_firstName,
      '_email' :_email,
      '_phone' :_phone,
     '_siret' :  _siret,
     '_password' : _password,
     '_token' :_token,
    '_expireDate' : _expireDate,
     '_stocks' : _stocks,
     '_addresses' :    _addresses
    }, httpOptions);
  }
  addMarket(_id : Guid,_name :string,_openingDate :Date): Observable<any> {
    
    return this.http.post('https://localhost:7136/api/market/', {
     '_id' : _id.toString(),
     '_name' : _name,
     '_openingDate' : _openingDate,
     '_stocks' : []
    }, httpOptions);
  }

  addStock(_id : Guid,_name :string,_value : number,_entrepriseName : string): Observable<any> {
    
    return this.http.post('https://localhost:7136/api/stocks/', {
     '_id' : _id.toString(),
     '_name' : _name,
     '_value' : _value,
     '_entrepriseName' : _entrepriseName
    }, httpOptions);
  }


  putStock(_id : Guid,_name :string,_value : number,_entrepriseName : string): Observable<any> {
    
    return this.http.put('https://localhost:7136/api/stocks/', {
     '_id' : _id,
     '_name' : _name,
     '_value' : Number(_value),
     '_entrepriseName' : _entrepriseName
    }, httpOptions);
  }
  
  getOrder(id : string) : Observable<Order>{  
    return this.http.get<Order>('https://localhost:7136/api/Order?id='+ id );
  }
  
  getUser(id : string) : Observable<User>{  
    return this.http.get<User>('https://localhost:7136/api/User?id='+ id );
  }
  getUserEmail(email : string) : Observable<User[]>{  
    return this.http.get<User[]>('https://localhost:7136/api/User/email?email='+ email );
  }

  getMarket(id : string) : Observable<Market>{  
    return this.http.get<Market>('https://localhost:7136/api/Market?id='+ id );
  }
  getStock(id : string) : Observable<Stock>{  
    return this.http.get<Stock>('https://localhost:7136/api/Stocks?id='+ id );
  }
  getNotif(id : string) : Observable<Notification>{  
    return this.http.get<Notification>('https://localhost:7136/api/Notification?id='+ id );
  }

 
  addNotif(_id : Guid,_textRappel :string , _sentAt : Date): Observable<any> {
    
    return this.http.post('https://localhost:7136/api/notification/', {
     '_id' : _id.toString(),
     'textRappel' : _textRappel,
     '__sentAt ' : _sentAt 
    }, httpOptions);
  }
  putNotif(_id : Guid,_textRappel :string , _sentAt : Date): Observable<any> {
    
    return this.http.put('https://localhost:7136/api/notification/', {
     '_id' : _id.toString(),
     'textRappel' : _textRappel,
     '__sentAt ' : _sentAt 
    }, httpOptions);
  }


  addOrder(_id : Guid,_orderName :string,_orderDate:Date,_stock : Stock, _nbStock : number): Observable<any> {
    
    return this.http.post('https://localhost:7136/api/order/', {
     '_id' : _id.toString(),
     '_orderName' : _orderName,
     '_orderDate' : _orderDate,
     '_stock' : _stock,
     '_nbStock' : _nbStock
    }, httpOptions);
  }
  
  putOrder(_id : Guid,_orderName :string,_orderDate:Date,_stock : Stock, _nbStock : number): Observable<any> {
    
    return this.http.put('https://localhost:7136/api/order/', {
     '_id' : _id.toString(),
     '_orderName' : _orderName,
     '_orderDate' : _orderDate,
     '_stock' : _stock,
     '_nbStock' : _nbStock
    }, httpOptions);
  }

  
  putMarket(_id : Guid,_name :string,_openingDate :Date): Observable<any> {
    
    return this.http.put('https://localhost:7136/api/market/', {
     '_id' : _id.toString(),
     '_name' : _name,
     '_openingDate' : _openingDate,
     '_stocks' : []
    }, httpOptions);
  }

    deleteNotification(id : string) : Observable<any> {

      return this.http.delete("https://localhost:7136/api/Notification/id?id="+ id);
    
   }

   deleteMarket(id : string)  : Observable<any> {
    return this.http.delete("https://localhost:7136/api/Market/id?id="+ id);
   }

   deleteOrder(id : string )  : Observable<any> {
    return this.http.delete("https://localhost:7136/api/order/id?id="+ id);
   }

   deleteUser(id : string )  : Observable<any>{
    return this.http.delete("https://localhost:7136/api/user/id?id="+ id);
   }

   deleteStock(id : string )  : Observable<any>{
    return this.http.delete("https://localhost:7136/api/stocks/id?id="+ id);
   }
}