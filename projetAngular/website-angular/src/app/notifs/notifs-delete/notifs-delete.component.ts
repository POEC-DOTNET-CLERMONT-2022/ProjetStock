import { Component, OnInit } from '@angular/core';
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
import { User } from 'src/models/User';

@Component({
  selector: 'app-notifs-delete',
  templateUrl: './notifs-delete.component.html',
  styleUrls: ['./notifs-delete.component.scss']
})
export class NotifsDeleteComponent implements OnInit {
  message : string  = '';
  notif : Notification = new Notification(Guid.createEmpty(),'',new Date());
  id : string = 'mon_id_notif';
  user : User  = new User(Guid.createEmpty(),'','','','','','');
  
  constructor(private authService: AuthService, private tokenStorage: TokenStorageService , public formBuilder : FormBuilder,public router : Router,private route: ActivatedRoute) {
 
  }


  ngOnInit(): void {

    this.id = this.route.snapshot.paramMap.get('id')!;

    this.authService.setIsLog(true);
    if (this.tokenStorage.getToken()) {

   this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);

   var json = JSON.stringify(this.user)
  
   this.id = this.route.snapshot.params['id'];

   
    }
    try{
      
     this.authService.deleteNotification(this.id).subscribe();
    }
    catch{
      console.log("ok");
    }

    this.router.navigate(['/notifs']);

 
  }

}
