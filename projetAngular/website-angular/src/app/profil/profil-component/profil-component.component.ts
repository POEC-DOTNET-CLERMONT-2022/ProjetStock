import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { User } from 'src/models/User';

import { AuthService } from 'src/services/service-auth/auth.service';
@Component({
  selector: 'app-profil-component',
  templateUrl: './profil-component.component.html',
  styleUrls: ['./profil-component.component.scss']
})
export class ProfilComponentComponent implements OnInit  {
  user : User| undefined;
  my_user : User| undefined;
  constructor(private authService: AuthService) { 

    if(window.sessionStorage.getItem('auth-user')){
      

   
    
      this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
    
      var json = JSON.stringify(this.user)
     

      var data =json.split(':');

      

      data[3].split(',')[0].split('"')[1]


      var email = data[3].split(',')[0].split('"')[1];

    this.authService.getUserEmail(email).subscribe((user : User) =>{
      this.my_user = user;
      
    });

    
   }
  }

  ngOnInit(): void {
    if(window.sessionStorage.getItem('auth-user')){
      

   
    
      this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
    
      var json = JSON.stringify(this.user)
     

      var data =json.split(':');

      

      data[3].split(',')[0].split('"')[1]


      var email = data[3].split(',')[0].split('"')[1];

    this.authService.getUserEmail(email).subscribe((user : User) =>{
      this.my_user = user;
      
    });

    
   }
      
  }


}
