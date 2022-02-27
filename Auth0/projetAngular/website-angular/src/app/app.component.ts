import { Component, OnInit } from '@angular/core';
import { User } from '@auth0/auth0-angular';
import { AuthService } from 'src/services/service-auth/auth.service';
import { TokenStorageService } from 'src/services/service-auth/token-storage.service';
import { NavbarComponent } from './navbar/navbar/navbar.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'website-angular';


  user : User[] = []

  constructor(public tokenStorage : TokenStorageService,public auth : AuthService){

  }

  ngOnInit(): void {
    
      if(window.sessionStorage.getItem("email")){
      
          console.log(window.sessionStorage.getItem("email"));
         this.auth.getUserEmailAuth0(String(window.sessionStorage.getItem("email"))).subscribe( (x : User[]) =>{
             this.user = x;
            console.log(x)
           if(x != undefined){

            this.tokenStorage.saveUser(x);
            window.sessionStorage.removeItem("email");
            NavbarComponent.IsConnected = true;
           }
           window.location.reload();
         
            
         })
       
         
        
        } 

          
        
  }
  
}


