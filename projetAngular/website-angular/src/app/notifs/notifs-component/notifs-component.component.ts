import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/services/UserService/user-service.service';
import { Notification } from 'src/models/Notification';
import { Router } from '@angular/router';
import { NavbarComponent } from 'src/app/navbar/navbar/navbar.component';
@Component({
  selector: 'app-notifs-component',
  templateUrl: './notifs-component.component.html',
  styleUrls: ['./notifs-component.component.scss']
})
export class NotifsComponentComponent implements OnInit {
  p: Number = 1;
  count: Number = 15;
  public  getCount() : Number{
    return  this.count;
  }

  public getP() : Number{
    return this.p;
  }
  
  _notifs : Notification[];

  static pathAjoutNotifs: string = 'ajout_notif';
  urlAjoutNotifs : string = '/' + NavbarComponent.pathAjoutNotifs;

  static pathModifNotif: string = 'modify_notifs';
  urlNotif : string = '/' + NavbarComponent.pathModifNotif+ '/:id';
 

  
  static pathSupNotif: string = 'delete_notifs';
  urlSupNotif : string = '/' + NavbarComponent.pathSupNotif+ '/:id';
 
  i : number = 0;
  constructor(private activateRoute : ActivatedRoute,public UserService : UserService,private router:Router) {

    this._notifs =[];

    this.callApi();
 
  }

  ngOnInit(): void {


  }




  callApi() :void{ 


   this.UserService.getNotifs().subscribe((notif : Notification[]) =>{
     this._notifs = notif;
    
  

   })


  }
}
