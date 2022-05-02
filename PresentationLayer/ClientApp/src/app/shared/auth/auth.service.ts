import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(public jwtHelper: JwtHelperService) { }

  public isAuthenticated(): boolean{
    const auth_token = localStorage.getItem("jwt")
    console.log("1:    "+auth_token)
    if(auth_token){
      let exp = !this.jwtHelper.isTokenExpired(auth_token);
      console.log(exp);
      return exp;

    }
    
    return false;
  }
}
