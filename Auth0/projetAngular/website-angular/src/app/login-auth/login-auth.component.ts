
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { NavbarComponent } from '../navbar/navbar/navbar.component';

  @Component({
    selector: 'app-login-auth',
    templateUrl: './login-auth.component.html',
    styleUrls: ['./login-auth.component.scss'],
  })
  export class  LoginAuthComponent implements OnInit {

    private readonly _httpClient: HttpClient;
    private readonly _authService: AuthService;
  
    constructor(httpClient: HttpClient, authService: AuthService) {
      this._httpClient = httpClient;
      this._authService = authService;
     
    }
  
  ngOnInit(): void {
      console.log("test");
  }


  public login(): void {
     this._authService.loginWithRedirect();
   
  
  }

  public logout() : void{
    this._authService.logout();
  
  }

}
