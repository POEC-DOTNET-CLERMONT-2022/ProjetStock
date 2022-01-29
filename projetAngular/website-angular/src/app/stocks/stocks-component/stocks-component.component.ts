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
import { NavbarComponent } from 'src/app/navbar/navbar/navbar.component';
import { Stock } from 'src/models/Stock';

@Component({
  selector: 'app-stocks-component',
  templateUrl: './stocks-component.component.html',
  styleUrls: ['./stocks-component.component.scss']
})
export class StocksComponentComponent implements OnInit {

 
  _stocks : Stock[];
  _user : User[] ;
  i : number = 0;
  static pathStockAdd: string = 'ajout_stocks';
  urlAjoutStock : string = '/' + NavbarComponent.pathStockAdd;
  static pathSupStock: string = 'delete_stock';
  urlSupStock : string = '/' + NavbarComponent.pathSupStock;
  static pathModStock: string = 'modify_stock';
  urlModStock : string = '/' + NavbarComponent.pathModStock;
  

  constructor(private activateRoute : ActivatedRoute,public UserService : UserService,private router:Router) {

    this._stocks =[];
    this._user =[];
    this.callApi();
  
  }
  
  ngOnInit(): void {


  }



  callApi() :void{ 


   this.UserService.getStocks().subscribe((stock : Stock[]) =>{
     this._stocks = stock;
   
   })


  }
}
