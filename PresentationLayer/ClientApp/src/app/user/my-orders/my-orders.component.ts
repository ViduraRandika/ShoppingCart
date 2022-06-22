import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/model/order';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css']
})
export class MyOrdersComponent implements OnInit {

  ordersTemp:any;
  orders:any=[];

  constructor(private service: UserService) { }

  ngOnInit(): void {
    this.getOrders();
    this.loadScript("assets/user/js/jquery-3.3.1.min.js");
    this.loadScript("assets/user/js/bootstrap.min.js");
    this.loadScript("assets/user/js/jquery.nice-select.min.js");
    this.loadScript("assets/user/js/jquery-ui.min.js");
    this.loadScript("assets/user/js/jquery.slicknav.js");
    this.loadScript("assets/user/js/mixitup.min.js");
    this.loadScript("assets/user/js/owl.carousel.min.js");
    this.loadScript("assets/user/js/main.js");
  }

  getOrders(){
    this.service.getOrders().subscribe((data: {}) => {
      // console.log(data);
      
      this.ordersTemp = data;
      for(var i = 0; i<this.ordersTemp.length; i++){
        var temp:Order = this.ordersTemp[i];
        this.orders.push(temp);
      }
    })
  }

  viewBill(orderId:number){
    
  }

  public loadScript(url: string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

}
