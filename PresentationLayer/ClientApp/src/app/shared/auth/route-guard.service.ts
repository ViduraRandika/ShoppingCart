import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class RouteGuardService implements CanActivate {

  constructor(private auth: AuthService, private router:Router) { }

  public canActivate(route: ActivatedRouteSnapshot,  state: RouterStateSnapshot): boolean{
    const expectedRole = route.data['expectedRole'];
    const auth_token = localStorage.getItem("jwt");

    if(expectedRole == "any"){
      return true;
    }else{
      if(auth_token){
        if(!this.auth.isAuthenticated()){
          this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
          return false;
        }

        const tokenPayload : any = decode(auth_token);
        let role = tokenPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    
        if(role !== expectedRole){
          this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
          return false;
        }

        return true;
      }else{
        this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
        return false;
      }
    }
  }
}
