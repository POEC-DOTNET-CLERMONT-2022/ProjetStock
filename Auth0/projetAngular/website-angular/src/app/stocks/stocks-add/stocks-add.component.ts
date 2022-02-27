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
import { Stock } from 'src/models/Stock';

@Component({
  selector: 'app-stocks-add',
  templateUrl: './stocks-add.component.html',
  styleUrls: ['./stocks-add.component.scss']
})
export class StocksAddComponent implements OnInit {
  user : User  = new User(Guid.createEmpty(),'','','','','','');
  stock : Stock = new Stock(Guid.create(),'',0,'');
  form: any = {
    name : null,
    entreprisename: null,
    _value: null

 
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
   


 

   


     }
    
     
   }
 
   onSubmit(): void {
  
    console.log(this.form.name);
    this.authService.addStock(Guid.create(),this.form.name,Number(this.form._value),this.form.entreprisename).subscribe(
       
      data => {
          
      
       
          this.router.navigate(['/stocks']);
        
       
      
      },
      err => {


          this.errorMessage = err.error.message;
        
      }
    );
 

   }
}
