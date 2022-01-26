import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/services/UserService/user-service.service';
import { Router } from '@angular/router';
import { Order } from 'src/models/Order';
import { Market } from 'src/models/Market';
import { NavbarComponent } from '../navbar/navbar/navbar.component';
@Component({
  selector: 'app-markets',
  templateUrl: './markets.component.html',
  styleUrls: ['./markets.component.scss']
})
export class MarketsComponent implements OnInit {

  _markets : Market[];

  static pathAjoutMarket: string = 'ajout_market';
  urlAjoutMarket : string = '/' + NavbarComponent.pathAjoutMarket;


  static pathUpdateMarket: string = 'modifier_market';
  urlUpdateMarket : string = '/' + NavbarComponent.pathUpdateMarket;
  i : number = 0;
  constructor(private activateRoute : ActivatedRoute,public UserService : UserService,private router:Router) {

    this._markets =[];

    this.callApi();

  }

  ngOnInit(): void {


  }




  callApi() :void{ 


   this.UserService.getMarkets().subscribe((market : Market[]) =>{
     this._markets = market;
   
   })


  }



}
