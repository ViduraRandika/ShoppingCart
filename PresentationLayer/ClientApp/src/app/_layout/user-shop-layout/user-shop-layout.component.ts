import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-shop-layout',
  templateUrl: './user-shop-layout.component.html',
  styleUrls: ['./user-shop-layout.component.css']
})
export class UserShopLayoutComponent implements OnInit {

  constructor() { }

  nav: any;

  ngOnInit(): void {
    this.loadScript("assets/user/js/jquery-3.3.1.min.js");
    this.loadScript("assets/user/js/bootstrap.min.js");
    this.loadScript("assets/user/js/jquery.nice-select.min.js");
    this.loadScript("assets/user/js/jquery-ui.min.js");
    this.loadScript("assets/user/js/jquery.slicknav.js");
    this.loadScript("assets/user/js/mixitup.min.js");
    this.loadScript("assets/user/js/owl.carousel.min.js");
    this.loadScript("assets/user/js/main.js");
  }

  onActiveChange(value: any){
    this.nav = value;
  }
  
  public loadScript(url: string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

}