import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { User } from 'src/models/User';
import { DataService } from 'src/services/Data-service/data-service';
import { AuthService } from 'src/services/service-auth/auth.service';
import { TokenStorageService } from 'src/services/service-auth/token-storage.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { NavbarComponent } from 'src/app/navbar/navbar/navbar.component';

@Component({
  selector: 'app-profil-component',
  templateUrl: './profil-component.component.html',
  styleUrls: ['./profil-component.component.scss']
})
export class ProfilComponentComponent implements OnInit  {
  user : User| undefined;
  my_user : User[] =  [];

  user_define : User  = new User(Guid.createEmpty(),'','','','','','');


 

    errorMessage = '';
    roles: string[] = [];
    id : Guid = Guid.create();
    public dataService : DataService = new DataService();
    constructor(private authService: AuthService, private tokenStorage: TokenStorageService , public router : Router,private route: ActivatedRoute) {
  
      if(window.sessionStorage.getItem('auth-user')){
      

   
    
        this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
      
        var json = JSON.stringify(this.user)
       
  
        var data =json.split(':');
  
        
  
      
  
  
        var email = data[3].split(',')[0].split('"')[1];
        this.authService.getUserEmail(email).subscribe((user : User[]) =>{
          this.my_user = user;
          this.user = (this.my_user[0]);
      
        });
    
     
  
     }
    }
  


  ngOnInit(): void {
    if(window.sessionStorage.getItem('auth-user')){
      

   
    
      this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
    
      var json = JSON.stringify(this.user)
     

      var data =json.split(':');

      

   

    
   }
      
  }



}
