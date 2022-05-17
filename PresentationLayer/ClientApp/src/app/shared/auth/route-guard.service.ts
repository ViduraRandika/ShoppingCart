import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';
import decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class RouteGuardService implements CanActivate {

  constructor(public auth: AuthService, public router:Router) { }

  public canActivate(route: ActivatedRouteSnapshot): boolean{
    const expectedRole = route.data['expectedRole'];
    const auth_token = localStorage.getItem("jwt");

    if(expectedRole == "any"){
      return true;
    }else{
      if(auth_token){
        if(!this.auth.isAuthenticated()){
          this.router.navigate(['login']);
          return false;
        }

        const tokenPayload : any = decode(auth_token);
        let role = tokenPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    
        if(role !== expectedRole){
          this.router.navigate(['home']);
          return false;
        }
      }

      return false;

      // return true;
    }
  }
}
