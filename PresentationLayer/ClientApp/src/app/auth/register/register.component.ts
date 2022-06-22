import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from 'src/app/shared/auth/register/register.service';
import Validation from 'src/app/shared/auth/register/validation.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterComponent implements OnInit {

  constructor(public service:RegisterService, private fb: FormBuilder, public router:Router) {}

  registerForm = this.fb.group({
    customerName: [''],
    customerAddress: [''],
    customerPhoneNumber: [''],
    email:[''],
    password:[''],
    confirmPassword:['']
  });
  ngOnInit(): void {
    this.registerForm = new FormGroup(
      {

        customerName: new FormControl("", [
          Validators.required,
          Validators.minLength(4)
        ]),

        email: new FormControl("",[
          Validators.required,
          Validators.email
        ]),

        customerAddress: new FormControl("",[
          Validators.required,
        ]),

        customerPhoneNumber: new FormControl("",[
          Validators.required,
          Validators.maxLength(10),
          Validators.minLength(10)
        ]),

        password: new FormControl("",[
          Validators.required,
          Validators.minLength(8),
          Validators.pattern("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}$")
        ]),

        confirmPassword: new FormControl("",[
          Validators.required,
        ])
      },
      {
        validators: [Validation.match('password','confirmPassword')]
      }
    );
  }

  get customerName(){
    return this.registerForm.get('customerName');
  }

  get email(){
    return this.registerForm.get('email');
  }
  
  get customerAddress(){
    return this.registerForm.get('customerAddress');
  }

  get customerPhoneNumber(){
    return this.registerForm.get('customerPhoneNumber');
  }

  get password(){
    return this.registerForm.get('password');
  }

  get confirmPassword(){
    return this.registerForm.get('confirmPassword');
  }

  
  // formData:Register
  onSubmit(formData:any){
    this.service.addCustomer(formData).subscribe((data: {}) => {
      window.alert("Account created successfully. Please log in")
      this.router.navigate(['/login']);
    });
  }

  navigate(url:string){
    this.router.navigate(
      [url]
    );
  }

}

