import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/User';
import { Guid } from 'guid-typescript';
import { DataService } from 'src/services/Data-service/data-service';
import { AuthService } from 'src/services/service-auth/auth.service';
import { TokenStorageService } from 'src/services/service-auth/token-storage.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { NavbarComponent } from 'src/app/navbar/navbar/navbar.component';
@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.scss']
})
export class UserAddComponent implements OnInit {

  user : User  = new User(Guid.createEmpty(),'','','','','','');


    form: any = {
       firstname : null,
       lastname : null,
       email: null,
       phone : null,
       siret: null,
       password :null
      };
      isLoggedIn = false;
      isLoginFailed = false;
      isEmail : boolean = false;
      errorMessage = '';
      roles: string[] = [];
      id : string = '';
      public dataService : DataService = new DataService();
      constructor(private authService: AuthService, private tokenStorage: TokenStorageService , public formBuilder : FormBuilder,public router : Router,private route: ActivatedRoute) {
    
      }
    
      
      ngOnInit(): void {
        
        this.form = this.formBuilder.group({});
        this.authService.setIsLog(true);
        if (this.tokenStorage.getToken()) {
          this.isLoggedIn = true;
          this.dataService.isLoggedIn = true;
          this.roles = this.tokenStorage.getUser().roles;
          this.roles = ['user'];
          
       this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
    
       var json = JSON.stringify(this.user)
      
       this.id = this.route.snapshot.params['id'];
       console.log(this.id)

    

      


        }
   
        
      }
    
      onSubmit(): void {
        const { firstname, lastname,email,phone, siret,password } = this.form;
        console.log(this.form.siret)
        const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        this.isEmail = regularExpression.test(String(this.form.email).toLowerCase());
        
        this.authService.addAccount(Guid.create(),this.form.lastName,this.form.FirstName,this.form.email,this.form.password,[],[],this.form.siret,phone,'',new Date()).subscribe(
          
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
      
             
                this.router.navigate(['/users']);
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
