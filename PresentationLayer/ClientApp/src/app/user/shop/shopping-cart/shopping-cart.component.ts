import { Component, OnInit } from '@angular/core';
import { CartItem } from 'src/app/model/cartItem';
import { AuthService } from 'src/app/shared/auth/auth.service';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  cartItemsTemp:any;
  cartItems:any= [];

  constructor(private authService: AuthService, private service: UserService) { }

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
    if(this.authService.customerAuthorization()){
      this.service.getCartItems().subscribe((data: {}) => {
        this.cartItemsTemp = data;
        for(var i = 0; i<this.cartItemsTemp.length; i++){
          var temp:CartItem = this.cartItemsTemp[i];
          this.cartItems.push(temp);
        }
      });
    }else{
      alert("Please log in to perform this action.")
    }
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
  
  public loadScript(url: string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }
}
