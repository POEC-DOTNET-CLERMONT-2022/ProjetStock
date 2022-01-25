
import { AuthService } from "src/services/service-auth/auth.service";
import {Router,CanActivate,ActivatedRouteSnapshot,RouterStateSnapshot} from '@angular/router';
import { Injectable } from "@angular/core";

@Injectable()
export class MyGuard implements CanActivate {

      constructor(public router : Router) {}
    
 
      
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

  
    if (window.sessionStorage.getItem('auth-user')) {
        var currentuser:any;
        currentuser =JSON.parse(window.sessionStorage.getItem('auth-user')!);
        if(currentuser){
          return true;
        }
    }
    this.router.navigate(['']);
    return false;
  }
 

      
    
}