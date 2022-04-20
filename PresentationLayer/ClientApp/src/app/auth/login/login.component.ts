import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/app/shared/auth/login/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent implements OnInit {

  constructor(public service:LoginService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.service.postLoginCredentials().subscribe(
      res=>{
        console.log(res)
      },err=>{
        if(err.status == 401){
          console.log("invalid email or password")
        }
      }
    );
  }

}
