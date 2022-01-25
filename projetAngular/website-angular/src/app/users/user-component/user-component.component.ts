import { Component, OnInit } from '@angular/core';
import { Observable, subscribeOn } from 'rxjs';
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
  _users : User[];
  _user : User[] ;
  i : number = 0;
  constructor(private activateRoute : ActivatedRoute,public UserService : UserService,private router:Router) {

    this._users =[];
    this._user =[];
    this.callApi();
    console.log(this._users);
 ;
    for (var product of this._users) {
      console.log(product) }

  }

  ngOnInit(): void {
   
  }


  callApi() : void{ 

  this.UserService.getUsers().subscribe((user: User) =>{
    this._users.push(user);
  })

  


  }

}
