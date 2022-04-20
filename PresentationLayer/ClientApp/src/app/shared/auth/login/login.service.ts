import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from './login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }

  formData:Login = new Login();

  postLoginCredentials(){
    return this.http.post('/api/auth/login',this.formData, {responseType:'text'})
  }
}
