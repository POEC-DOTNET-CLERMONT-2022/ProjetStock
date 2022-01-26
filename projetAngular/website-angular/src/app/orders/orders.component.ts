import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/services/UserService/user-service.service';
import { Router } from '@angular/router';
import { Order } from 'src/models/Order';
@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  _orders : Order[];

  i : number = 0;
  constructor(private activateRoute : ActivatedRoute,public UserService : UserService,private router:Router) {

    this._orders =[];

    this.callApi();
  
  }

  ngOnInit(): void {


  }




  callApi() :void{ 


   this.UserService.getOrders().subscribe((order : Order[]) =>{
     this._orders = order;
   
   })


  }

}
