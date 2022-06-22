import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartItem } from 'src/app/model/cartItem';
import { AuthService } from 'src/app/shared/auth/auth.service';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-user-shop-layout',
  templateUrl: './user-shop-layout.component.html',
  styleUrls: ['./user-shop-layout.component.css']
})
export class UserShopLayoutComponent implements OnInit {

  constructor(private authService: AuthService, private service: UserService, private router:Router) { }

  nav: any;
  login: string;
  login_href: string;
  cartItemsCount : any;
  cartTotal : number;

  cartItemsTemp:any;
  cartItems:any= [];

  ngOnInit(): void {
    this.loadScript("assets/user/js/jquery-3.3.1.min.js");
    this.loadScript("assets/user/js/bootstrap.min.js");
    this.loadScript("assets/user/js/jquery.nice-select.min.js");
    this.loadScript("assets/user/js/jquery-ui.min.js");
    this.loadScript("assets/user/js/jquery.slicknav.js");
    this.loadScript("assets/user/js/mixitup.min.js");
    this.loadScript("assets/user/js/owl.carousel.min.js");
    this.loadScript("assets/user/js/main.js");
    this.updateNav();
  }

  onActiveChange(value: any){
    this.nav = value;
  }

  updateNav(){
    if(this.authService.customerAuthorization()){
      var user_details : any = this.authService.getUserDetails();
      this.login = user_details['name']
      this.login_href = "#"
    }else{
      this.login = "Login"
      this.login_href = "/login"
    }

    this.getCartDetails();
  }
  

  getCartDetails(){
    if(this.authService.customerAuthorization()){
      this.service.getCartItems("open").subscribe((data: {}) => {
        this.cartItemsTemp = data;
        // this.cartItemsCount = this.cartItemsTemp.length;
        // console.log(this.cartItemsTemp.length)
        // console.log(this.cartItemsTemp)
        this.cartItemsCount = 0;
        this.cartTotal = 0;
        for(var i = 0; i<this.cartItemsTemp.length; i++){
          this.cartItemsCount = this.cartItemsCount + this.cartItemsTemp[i]['qty'];
          this.cartTotal = this.cartTotal + (this.cartItemsTemp[i]['price'] * this.cartItemsTemp[i]['qty']);
          var temp:CartItem = this.cartItemsTemp[i];
          this.cartItems.push(temp);
        }

        console.log(this.cartTotal);
        
      });
    }else{
      this.cartItemsCount = 0;
      this.cartTotal = 0;
    }
  }

  public loadScript(url: string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

  navigate(url:string){
    this.router.navigate(
      [url]
    );
  }

}
