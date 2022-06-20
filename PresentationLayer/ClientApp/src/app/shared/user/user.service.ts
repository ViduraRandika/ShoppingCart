import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  getCategories(){
    return this.http
      .get('/api/view-categories', {responseType: 'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  getProducts(){
    return this.http
      .get('/api/view-products', {responseType: 'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  getSelectedCategoryProducts(id:number){
    return this.http
      .get(`/api/view-products/${id}`, {responseType: 'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  getSelectedProductDetails(id:number){
    return this.http
      .get(`/api/product-details/${id}`,{responseType:'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  addProductToCart(productId:number,qty:number){
    return this.http
      .post('/api/user/addProductToCart?produtctId='+productId+'&qty='+qty,null,{responseType:'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  getCartItems(){
    return this.http
      .get(`/api/user/getCartItems`,{responseType:'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  updateCartItemQty(id:number, qty:number){
    return this.http
      .post('/api/user/updateCartItems?id='+id+'&qty='+qty,null,{responseType:'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  productRemoveFromCart(productId:number){
    return this.http
      .delete('/api/user/removeProductFromCart?productId='+productId,{responseType:'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
  }

  testApi(){
    return this.http
      .get('/api/user/test',{responseType:'json'})
      .pipe(
        catchError(
          this.handleError
        )
      )
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
