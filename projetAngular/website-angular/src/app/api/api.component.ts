import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from 'src/services/service-auth/token-storage.service';
import { User } from 'src/models/User';
import { Guid } from 'guid-typescript';
import { FormBuilder } from '@angular/forms';
import { AuthService } from 'src/services/service-auth/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.scss']
})
export class ApiComponent implements OnInit {
  errorMessage = '';
  roles: string[] = [];
  api_key :string = '';
  isApiHave :  boolean  = false;
  isSendFailed : boolean = false;
  user : User  = new User(Guid.createEmpty(),'','','','','','') ;
  form: any = {
     password: null,
     password_confirm: null
   };
   isLoggedIn = false;
   isLoginFailed = false;
   isEmail : boolean = false;
   _email : string = '';
  constructor(private tokenStorage : TokenStorageService, public formBuilder : FormBuilder,private authService: AuthService,public router : Router) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({});
    if (this.tokenStorage.getToken()) {

          this.roles = this.tokenStorage.getUser().roles;
          this.roles = ['user'];
          
       this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
    
       var json = JSON.stringify(this.user)
      

       var data =json.split(':');

       if( data[4] != null){

        this.isApiHave = true;
        this.api_key = data[4].split("}")[0];
        this._email = data[3].split(',')[0];
     
       }
   

      
    

        }
  }


  onSubmit() :void {
    const { password_confirm, password } = this.form;
    this._email = this._email.split('"')[1];
    this.authService.generateApiKey(this._email,password).subscribe(
      
        data => {
          if( password == password_confirm)
          {
            this.tokenStorage.saveToken(data.accessToken);
            this.tokenStorage.saveUser(data);
    
            
            this.isLoginFailed = false;
            this.isLoggedIn = true;
  
            this.authService.setIsLog(true);
            this.roles = ['user'];
            this.roles = this.tokenStorage.getUser().roles;
  
            this.reloadPage();
            this.router.navigate(['api']);
          }
         
        
        },
        err => {
          if(err.status == 400)
          {
          
            this.isLoggedIn = false;
            this.isSendFailed = true;
            this.errorMessage = "No generate";
        
          }
         
        }
      );
   
    
  }

  reloadPage(): void {
    window.location.reload();
  }

}
