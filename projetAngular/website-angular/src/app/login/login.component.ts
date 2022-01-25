import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Form, FormBuilder, FormGroup,Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from 'src/services/service-auth/auth.service';

import { TokenStorageService } from 'src/services/service-auth/token-storage.service';
import { NavbarComponent } from '../navbar/navbar/navbar.component';
import { DataService } from 'src/services/Data-service/data-service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']

})

export class LoginComponent implements OnInit {
  
    
  static pathregister: string = 'register';
  urlRegister : string = '/' + NavbarComponent.pathregister;

    form: any = {
       email: null,
        password: null
      };
      isLoggedIn = false;
      isLoginFailed = false;
      isEmail : boolean = false;
      errorMessage = '';
      roles: string[] = [];
      public dataService : DataService = new DataService();
      constructor(private authService: AuthService, private tokenStorage: TokenStorageService , public formBuilder : FormBuilder,) {
 
      }
    
      
      ngOnInit(): void {
        this.form = this.formBuilder.group({});
        this.authService.setIsLog(true);
        if (this.tokenStorage.getToken()) {
          this.isLoggedIn = true;
          this.dataService.isLoggedIn = true;
          this.roles = this.tokenStorage.getUser().roles;
          this.roles = ['user'];

        }
   
        
      }
    
      onSubmit(): void {
        const { email, password } = this.form;
        const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        this.isEmail = regularExpression.test(String(email).toLowerCase());
        this.authService.login(email,password).subscribe(
          
            data => {
                
              console.log(this.isEmail);
              if( password != null || this.isEmail == true)
              {
                this.tokenStorage.saveToken(data.accessToken);
                this.tokenStorage.saveUser(data);
        
                this.isLoginFailed = false;
                this.isLoggedIn = true;
      
                this.authService.setIsLog(true);
                this.roles = ['user'];
                this.roles = this.tokenStorage.getUser().roles;
                
                this.reloadPage();
              }
             
            
            },
            err => {
              if(err.status == 400)
              {
              
                this.isLoggedIn = false;
                this.isLoginFailed = true;
                this.authService.setIsLog(false);
                this.errorMessage = err.error.message;
                this.tokenStorage.deleteToken();
            
              }
              if( this.isEmail == false){
                this.isLoggedIn = false;
                this.isLoginFailed = true;
                this.errorMessage = "Error email";
                
              }
              else{
                   this.isLoggedIn = false;
                this.isLoginFailed = true;
                this.errorMessage = "Error authentication";
              }

             
            }
          );
       
      
        
      }
    
      reloadPage(): void {
        window.location.reload();
      }
}
