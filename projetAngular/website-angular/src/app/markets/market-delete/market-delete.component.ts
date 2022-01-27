
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
  selector: 'app-market-delete',
  templateUrl: './market-delete.component.html',
  styleUrls: ['./market-delete.component.scss']
})
export class MarketDeleteComponent implements OnInit {
  message : string  = '';
  
  market : Market = new Market(Guid.createEmpty(),'', new Date(),new Date());

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
      
     this.authService.deleteMarket(this.id).subscribe();
    }
    catch{
      console.log("ok");
    }

    this.router.navigate(['/market']);

 
 
  }
 
  }
