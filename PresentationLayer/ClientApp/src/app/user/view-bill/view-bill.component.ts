import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CartItem } from 'src/app/model/cartItem';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-view-bill',
  templateUrl: './view-bill.component.html',
  styleUrls: ['./view-bill.component.css']
})
export class ViewBillComponent implements OnInit {

  id:number;
  cartItemsTemp:any;
  cartItems:any= [];
  billDetails:any;
  dateTime:any;

  constructor(private service:UserService,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params=>{
        this.id = params['id'];
      }
    );

    this.service.getBill(this.id).subscribe((billDetails: any) => {
      this.billDetails = billDetails;
      console.log(billDetails);
      this.dateTime = new Date('0001-01-01T00:00:00');
      
        this.getCartItems(billDetails.cartId);
    });

    this.loadScript("assets/user/js/jquery-3.3.1.min.js");
    this.loadScript("assets/user/js/bootstrap.min.js");
    this.loadScript("assets/user/js/jquery.nice-select.min.js");
    this.loadScript("assets/user/js/jquery-ui.min.js");
    this.loadScript("assets/user/js/jquery.slicknav.js");
    this.loadScript("assets/user/js/mixitup.min.js");
    this.loadScript("assets/user/js/owl.carousel.min.js");
    this.loadScript("assets/user/js/main.js");
  }

  getCartItems(cartId:number){
    this.service.getCartItemsByCartId(cartId).subscribe((data: {}) => {
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

  public loadScript(url: string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

}
