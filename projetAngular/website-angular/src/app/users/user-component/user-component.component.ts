import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/models/User';
import { UserService } from 'src/services/UserService/user-service.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-user-component',
  templateUrl: './user-component.component.html',
  styleUrls: ['./user-component.component.scss']
})
export class UserComponentComponent implements OnInit {
  _users : User[]  = [];
  constructor(private activateRoute : ActivatedRoute,public UserService : UserService) { }

  ngOnInit(): void {
 
  }

  callApi() : void{
    this.activateRoute.params.subscribe((param) =>{
      this.UserService.getUsers().subscribe((user : User) =>{
        this._users.push(user);
        console.log(user);
      });
    });
  }

}
