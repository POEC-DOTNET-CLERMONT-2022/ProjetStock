
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
  selector: 'app-market-update',
  templateUrl: './market-update.component.html',
  styleUrls: ['./market-update.component.scss']
})
export class MarketUpdateComponent implements OnInit {
  user : User  = new User(Guid.createEmpty(),'','','','','','');

  market : Market = new Market(Guid.createEmpty(),'', new Date(),new Date());
  form: any = {
    name : null,
    openingDate : null
 
   };
   isLoggedIn = false;
   isLoginFailed = false;
   errorMessage = '';
   roles: string[] = [];
   id : string = 'test';
   public dataService : DataService = new DataService();
   constructor(private authService: AuthService, private tokenStorage: TokenStorageService , public formBuilder : FormBuilder,public router : Router,private route: ActivatedRoute) {
 
   }
 
   
   ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id')!;

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


 

   


     }
     this.authService.getMarket(this.id).subscribe((market : Market) =>{
       
       this.market = market;
       this.market.Name = market.Name;
       this.market.OpeningDate = market.OpeningDate;
       this.market.ClosingDate = market.ClosingDate;
       this.market.Stocks =  market.Stocks;
     
     })
     
   }
 
   onSubmit(): void {
  
    this.authService.putMarket(Guid.parse(this.market['_id'].toString()),this.form.name,new Date(this.form.openingDate.toString())).subscribe(
       
      data => {
          
      
          this.tokenStorage.saveToken(data.accessToken);
          this.tokenStorage.saveUser(data);
  
          
          this.isLoginFailed = false;
          this.isLoggedIn = true;

          this.authService.setIsLog(true);
          this.roles = ['user'];
          this.roles = this.tokenStorage.getUser().roles;

       
          this.router.navigate(['/market']);
        
       
      
      },
      err => {


          this.errorMessage = err.error.message;
        
      }
    );
 

   }

}
