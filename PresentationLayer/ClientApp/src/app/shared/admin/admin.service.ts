import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  postCreateCategory(formData:any){
    let auth_token = localStorage.getItem("jwt")
  
    const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${auth_token}`
      });

    return this.http
      .post('/api/admin/create-category',formData,  {headers, responseType: 'text'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  getCategories(){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http
      .get('/api/admin/view-categories', {responseType: 'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  postAddProduct(formData:any){
    return this.http
      .post('/api/admin/add-product',formData,{responseType: 'text'})
      .pipe(catchError(
        this.handleError
      ))
  }

  uploadImg(data:any){
    return this.http
    .post('/api/admin/uploadProductImage', data)
    .pipe(catchError(
        this.handleError
    ))
  }

  handleError(error: any){
    let errorMessage = '';
    console.log(error)
    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.message;
    }else{
      errorMessage = `Something went wront. Please try again.`
    }

    window.alert(errorMessage);

    return throwError(() => {
      return errorMessage;
    });
  }
}
