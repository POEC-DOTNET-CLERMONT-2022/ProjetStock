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
import { Notification } from 'src/models/Notification';
@Component({
  selector: 'app-notifs-modify',
  templateUrl: './notifs-modify.component.html',
  styleUrls: ['./notifs-modify.component.scss']
})
export class NotifsModifyComponent implements OnInit {
  user : User  = new User(Guid.createEmpty(),'','','','','','');
  notif : Notification = new Notification(Guid.createEmpty(),'',new Date());
  form: any = {
    textrappel : null,
    sendAt : null

 
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
     this.authService.getNotif(this.id).subscribe((notif : Notification) =>{
       
       this.notif = notif;
     
     })
     
   }
 
   onSubmit(): void {
  
    this.authService.putNotif(this.notif['id'],this.form.textrappel,new Date(this.form.sendAt.toString())).subscribe(
       
      data => {
          
      
 
       
          this.router.navigate(['/notifs']);
        
       
      
      },
      err => {


          this.errorMessage = err.error.message;
        
      }
    );
 

   }
}
