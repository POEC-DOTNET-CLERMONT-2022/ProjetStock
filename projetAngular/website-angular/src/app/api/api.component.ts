import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from 'src/services/service-auth/token-storage.service';
import { User } from 'src/models/User';
import { Guid } from 'guid-typescript';
@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.scss']
})
export class ApiComponent implements OnInit {
  errorMessage = '';
  roles: string[] = [];
  api_key :string = '';
  isApiHave :  boolean  = false;
  user : User  = new User(Guid.createEmpty(),'','','','','','') ;
  constructor(private tokenStorage : TokenStorageService) { }

  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {

          this.roles = this.tokenStorage.getUser().roles;
          this.roles = ['user'];
          
       this.user = JSON.parse(window.sessionStorage.getItem('auth-user')!);
    
       var json = JSON.stringify(this.user)
      

       var data =json.split(':');
      
       if( data[4] != null){

        this.isApiHave = true;
        this.api_key = data[4].split("}")[0];
     
       }
   

      
    

        }
  }

}
