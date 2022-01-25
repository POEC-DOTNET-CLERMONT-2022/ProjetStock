import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { User } from 'src/models/User';
@Component({
  selector: 'app-profil-component',
  templateUrl: './profil-component.component.html',
  styleUrls: ['./profil-component.component.scss']
})
export class ProfilComponentComponent implements OnInit {
  user : User| undefined;
  constructor() { 

    if(window.sessionStorage.getItem('auth-user')){
      

   
    
      this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
    
       var json = JSON.stringify(this.user)
      

       var data =json.split(':');
      

      

      
       
       
    console.log(data);
      
    
   }
  }

  ngOnInit(): void {
    
  }

}
