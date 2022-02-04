
import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/User';
import {Market } from 'src/models/Market';
import { Guid } from 'guid-typescript';
import { DataService } from 'src/services/Data-service/data-service';
import { AuthService } from 'src/services/service-auth/auth.service';
import { TokenStorageService } from 'src/services/service-auth/token-storage.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { NavbarComponent } from 'src/app/navbar/navbar/navbar.component';

@Component({
  selector: 'app-market-add',
  templateUrl: './market-add.component.html',
  styleUrls: ['./market-add.component.scss']
})
export class MarketAddComponent implements OnInit {
  user : User  = new User(Guid.createEmpty(),'','','','','','');
  

  form: any = {
    name : null,
    openingDate : null
 
   };
   isLoggedIn = false;
   isLoginFailed = false;
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

     this.authService.addMarket(Guid.create(),this.form.name,this.form.openingDate).subscribe(
       
         data => {
             
         

          
             this.router.navigate(['/market']);
           
          
         
         },
         err => {

  
             this.errorMessage = err.error.message;
           
         }
       );
    
   
     
   }
 
   reloadPage(): void {
     window.location.reload();
   }
}
