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
    form: any = {
       email: null,
        password: null
      };
      isLoggedIn = false;
      isLoginFailed = false;
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
        }
        console.log(this.dataService.isLoggedIn);
        
      }
    
      onSubmit(): void {
        const { email, password } = this.form;
        this.authService.login(email,password).subscribe(
          
            data => {
                
            
                this.tokenStorage.saveToken(data.accessToken);
                this.tokenStorage.saveUser(data);
        
                this.isLoginFailed = false;
                this.isLoggedIn = true;
      
                this.authService.setIsLog(true);
                this.roles = this.tokenStorage.getUser().roles;
                this.reloadPage();
                
            
            },
            err => {
              if(err.status == 400)
              {
                console.log(err);
                this.isLoggedIn = false;
                this.authService.setIsLog(false);
                this.errorMessage = err.error.message;
                this.tokenStorage.deleteToken();
                this.reloadPage();
              }
             
            }
          );
       
      
        
      }
    
      reloadPage(): void {
        window.location.reload();
      }
}
