import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/models/User';
import { UserService } from 'src/services/UserService/user-service.service';
import { ActivatedRoute } from '@angular/router';

import { ActivatedRouteSnapshot } from '@angular/router';
import { RouterStateSnapshot } from '@angular/router';
import { CanActivate } from '@angular/router';
import { MyGuard } from 'src/app/helpers/auth.guard';
import { UrlTree } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-component',
  templateUrl: './user-component.component.html',
  styleUrls: ['./user-component.component.scss']
})
export class UserComponentComponent implements OnInit{
  _users : User[]  = [];
  constructor(private activateRoute : ActivatedRoute,public UserService : UserService,private router:Router) {
    
    this.callApi();
    console.log(this._users);
   }

  ngOnInit(): void {
   
  }


  callApi() : void{
    this.activateRoute.params.subscribe((param) =>{
      this.UserService.getUsers().subscribe((user : User) =>{
        this._users.push(user);
        
      });
    });
  }

}
