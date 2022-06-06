import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from 'src/app/shared/auth/login/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent implements OnInit {

  constructor(private service:LoginService, private fb: FormBuilder, private router:Router, private route:ActivatedRoute) { }

  loginForm = this.fb.group({
      email: [''],
      password: ['']
  });

  returnUrl: string;

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home';

    this.loginForm = new FormGroup(
      {
        email: new FormControl("",[
          Validators.required,
          Validators.email,
        ]),

        password: new FormControl("",[
          Validators.required,
        ]),
      }
    )
  }

  get email(){
    return this.loginForm.get('email')
  }

  get password(){
    return this.loginForm.get('password')
  }

  onSubmit(formData:any){
    this.service.postLoginCredentials(formData).subscribe(
    (data: string) => {
      localStorage.setItem("jwt",data)
      window.alert("Logged in successfully")
      this.router.navigateByUrl(this.returnUrl);
    },
    (error: string) => {
      window.alert(error)
    }
    )
  }
}
