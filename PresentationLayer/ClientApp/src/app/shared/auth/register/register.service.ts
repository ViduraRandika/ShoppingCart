import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, throwError } from 'rxjs';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http:HttpClient) { }


  addCustomer(formData:any){
    return this.http
      .post('/api/user/add',formData, {responseType:'text'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  handleError(error:any){
    let errorMessage = '';
    
    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.message;
    }else{
      if(error.status == 409)
        errorMessage = `An account is already registered with your email address.`;
      else{
        errorMessage = `Something went wront. Please try again.`
      }
    }

    Swal.fire({
      title: 'Error!',
      text: errorMessage,
      icon: 'error',
    })

    return throwError(() => {
      return errorMessage;
    });
  }

}
 