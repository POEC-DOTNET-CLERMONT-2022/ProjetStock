
import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/User';
import {Order } from 'src/models/Order';
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
  selector: 'app-orders-modify',
  templateUrl: './orders-modify.component.html',
  styleUrls: ['./orders-modify.component.scss']
})
export class OrdersModifyComponent implements OnInit {

  user : User  = new User(Guid.createEmpty(),'','','','','','');
  stock = new Stock(Guid.create(),'',0,'');
  order : Order  = new Order(Guid.createEmpty(),'',new Date(),this.stock,0);

  form: any = {
    ordername : null,
    orderdate : null,
    stock : Stock ,
    nbStock : null
 
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

 

   


     }

     this.authService.getOrder(this.id).subscribe((order : Order) =>{
       
      this.order = order;
     
     })
     
     
   }
 
   onSubmit(): void {


     this.authService.putOrder(Guid.create(),this.form.ordername,this.form.orderDate,this.order.$stock,this.form.nbstock).subscribe(
       
         data => {
             
         
        
          
             this.router.navigate(['/orders']);
           
          
         
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
