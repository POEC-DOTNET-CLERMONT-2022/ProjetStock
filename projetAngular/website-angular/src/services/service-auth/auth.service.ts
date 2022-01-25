import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'https://localhost:7136/api/user/authenticate';

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
     
     return this.http.post(AUTH_API, {
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
}