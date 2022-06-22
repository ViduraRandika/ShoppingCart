import { Component, OnInit } from '@angular/core';
import { CartItem } from 'src/app/model/cartItem';
import { AuthService } from 'src/app/shared/auth/auth.service';
import { UserService } from 'src/app/shared/user/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  cartItemsTemp:any;
  cartItems:any= [];

  constructor(private service: UserService) { }

  ngOnInit(): void {
    this.getCartItems();
    this.loadScript("assets/user/js/jquery-3.3.1.min.js");
    this.loadScript("assets/user/js/bootstrap.min.js");
    this.loadScript("assets/user/js/jquery.nice-select.min.js");
    this.loadScript("assets/user/js/jquery-ui.min.js");
    this.loadScript("assets/user/js/jquery.slicknav.js");
    this.loadScript("assets/user/js/mixitup.min.js");
    this.loadScript("assets/user/js/owl.carousel.min.js");
    this.loadScript("assets/user/js/main.js");

    
  }

  getCartItems(){
    this.service.getCartItems().subscribe((data: {}) => {
      this.cartItemsTemp = data;
      for(var i = 0; i<this.cartItemsTemp.length; i++){
        var temp:CartItem = this.cartItemsTemp[i];
        this.cartItems.push(temp);
      }
    });
  }

  cartItemTotal(qty:string, price: number){
    return parseInt(qty) * price;
  }

  cartFullTotal(){
    var total = 0;
    for(var i = 0; i < this.cartItems.length; i++){
      total = total + (this.cartItems[i]['price'] * this.cartItems[i]['qty']);
    }
    return total;
  }


  updateCartItem(i:number,qty:string){
    var q = parseInt(qty);
    this.cartItems[i]['qty'] = q;

    this.updateQtyDatabase(this.cartItems[i]['id'],q);
  }

  updateQtyDatabase(id:number,qty:number){
    this.service.updateCartItemQty(id,qty).subscribe();
  }

  removeItemFromCart(id:number,productId:number){
    this.service.productRemoveFromCart(productId).subscribe();
    this.cartItems.splice(id,1);
  }
  
  public loadScript(url: string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

  placeOrder(){
    const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
      title: 'Are you sure?',
      text: "Please click on confirm button to place an order.",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Confirm',
      cancelButtonText: 'No, cancel!',
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {
        
        this.service.placeOrder(this.cartFullTotal()).subscribe(()=>{
          Swal.fire({
            title: 'Order placed !',
            text: "Thank you for shopping with us",
            icon: 'success',
            allowOutsideClick:false,
            allowEscapeKey:false,
            confirmButtonText:'Continue'
          }).then(function() {
              window.location.href = "/user/my-orders";
          });
        });

      }
    })




    
  }
}
