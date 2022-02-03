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
  _user_token : string ='';
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
    
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ this._user_token
   });
     return this.http.put('https://localhost:7136/api/user/', {
      'id' :_id,
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
     },  {headers : reqHeader});
   }

   addAccount(_id : Guid,_lastName : string , _firstName :string , _email: string, _password: string,_stocks : Stock[],_addresses :Address[],_siret : string,_phone : string, _token: string,_expireDate : Date): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.post('https://localhost:7136/api/user/', {
      'id' :Guid.create().toString(),
     '_lastName' : _lastName,  
      '_firstName' :_firstName,
      '_email' :_email,
      '_phone' :_phone,
     '_siret' :  _siret,
     '_password' : _password,
     '_token' : " ",
    '_expireDate' : _expireDate,
     '_stocks' : _stocks,
     '_addresses' :    _addresses
    }, {headers : reqHeader});
  }
  addMarket(_id : Guid,_name :string,_openingDate :Date): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.post('https://localhost:7136/api/market/', {
     'id' : Guid.create().toString(),
     '_name' : _name,
     '_openingDate' : _openingDate,
     '_stocks' : []
    }, {headers : reqHeader});
  }

  addStock(_id : Guid,_name :string,_value : number,_entrepriseName : string): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+token.split('"')[1]
   });
    return this.http.post('https://localhost:7136/api/stocks/', {
     'id' : Guid.create().toString(),
     '_name' : _name,
     '_value' : _value,
     '_entrepriseName' : _entrepriseName
    }, {headers :reqHeader});
  }
  putStock(_id : Guid,_name :string,_value : number,_entrepriseName : string): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
   console.log(this._user_token)
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+  this._user_token
   });
    return this.http.put('https://localhost:7136/api/stocks/', {
     'id' : _id,
     '_name' : _name,
     '_value' : 1,
     '_entrepriseName' : _entrepriseName
    }, {headers :reqHeader});
  }
  
  getOrder(id : string) : Observable<Order>{  
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+  token.split('"')[1]
   });
    return this.http.get<Order>('https://localhost:7136/api/Order?id='+ id , {headers :reqHeader});
  }
  
  getUser(id : string) : Observable<User>{  
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+  token.split('"')[1]
   });
    return this.http.get<User>('https://localhost:7136/api/User?id='+ id , {headers : reqHeader});
  }

  getUserEmail(email : string) : Observable<User[]>{
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   var email = data[3].split(',')[0];
   console.log(email)
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+  token.split('"')[1]
   });  
    return this.http.get<User[]>('https://localhost:7136/api/User/email?email='+ email , {headers :reqHeader});
  }

  getMarket(id : string) : Observable<Market>{  
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+  this._user_token
   });
    return this.http.get<Market>('https://localhost:7136/api/Market?id='+ id , {headers :reqHeader});
  }
  getStock(id : string) : Observable<Stock>{ 
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+  token.split('"')[1]
   }); 
    return this.http.get<Stock>('https://localhost:7136/api/Stocks?id='+ id, {headers :reqHeader} );
  }
  getNotif(id : string) : Observable<Notification>{  
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+  token.split('"')[1]
   });
    return this.http.get<Notification>('https://localhost:7136/api/Notification?id='+ id, {headers :reqHeader} );
  }

 
  addNotif(_id : Guid,_textRappel :string , _sentAt : Date): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.post('https://localhost:7136/api/notification/', {
     'id' : Guid.create().toString(),
     'textRappel' : _textRappel,
     '__sentAt ' : _sentAt 
    }, {headers :reqHeader});
  }

  putNotif(_id : Guid,_textRappel :string , _sentAt : Date): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+token.split('"')[1]
   });
    return this.http.put('https://localhost:7136/api/notification/', {
     'id' : _id.toString(),
     'textRappel' : _textRappel,
     '_sentAt ' : _sentAt 
    }, {headers :reqHeader});
  }


  addOrder(_id : Guid,_orderName :string,_orderDate:Date,_stock : Stock, _nbStock : number): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.post('https://localhost:7136/api/order/', {
     'id' : Guid.create().toString(),
     '_orderName' : _orderName,
     '_orderDate' : _orderDate,
     '_stock' : _stock,
     '_nbStock' : _nbStock
    }, {headers: reqHeader});
  }
  
  putOrder(_id : Guid,_orderName :string,_orderDate:Date,_stock : Stock, _nbStock : number): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.put('https://localhost:7136/api/order/', {
     'id' : _id.toString(),
     '_orderName' : _orderName,
     '_orderDate' : _orderDate,
     '_stock' : _stock,
     '_nbStock' : _nbStock
    }, {headers :reqHeader});
  }

  
  putMarket(_id : Guid,_name :string,_openingDate :Date): Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ this._user_token
   });
    return this.http.put('https://localhost:7136/api/market/', {
     'id' : _id.toString(),
     '_name' : _name,
     '_openingDate' : _openingDate,
     '_stocks' : []
    }, {headers : reqHeader});
  }

    deleteNotification(id : string) : Observable<any> {
      var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
      var data =json.split(':');
     var token = data[4].split(',')[0];
     this._user_token =token.split('"')[1];
      var reqHeader = new HttpHeaders({ 
        'Content-Type': 'application/json',
      
        'Authorization': 'Bearer '+ token.split('"')[1]
     });
      return this.http.delete("https://localhost:7136/api/Notification/id?id="+ id, {headers :reqHeader});
    
   }

   deleteMarket(id : string)  : Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.delete("https://localhost:7136/api/Market/id?id="+ id+"", {headers :reqHeader});
   }

   deleteOrder(id : string )  : Observable<any> {
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.delete("https://localhost:7136/api/order/id?id="+ id,{headers:reqHeader});
   }

   deleteUser(id : string )  : Observable<any>{
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.delete("https://localhost:7136/api/user/id?id="+ id, {headers:reqHeader});
   }

   deleteStock(id : string )  : Observable<any>{
    var json = JSON.stringify(JSON.parse(window.sessionStorage.getItem('auth-user')!))
    var data =json.split(':');
   var token = data[4].split(',')[0];
   this._user_token =token.split('"')[1];
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
    
      'Authorization': 'Bearer '+ token.split('"')[1]
   });
    return this.http.delete("https://localhost:7136/api/stocks/id?id="+ id, {headers:reqHeader});
   }
}