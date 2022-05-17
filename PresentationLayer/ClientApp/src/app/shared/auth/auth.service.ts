import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import decode from 'jwt-decode';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(public jwtHelper: JwtHelperService) {}

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

  public getUserDetails(): object{
    const auth_token = localStorage.getItem("jwt");
    if(auth_token){
      const tokenPayload : any = decode(auth_token);
      const obj = {
        exp: tokenPayload["exp"],
        role: tokenPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
        email: tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
        pno: tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone"],
        name: tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
        address:tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/streetaddress"],
      }
      return obj;
    }

    return {};
  }
}
