import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/model/product';
import { AuthService } from 'src/app/shared/auth/auth.service';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-prooduct-details',
  templateUrl: './prooduct-details.component.html',
  styleUrls: ['./prooduct-details.component.css']
})
export class ProoductDetailsComponent implements OnInit {

  id:number;
  productDetails:Product;
  constructor(private service:UserService, private route:ActivatedRoute, private authService:AuthService) { }
  public itemCounts = 1;
  ngOnInit(): void {
    this.route.queryParams
      .subscribe(params=>{
        this.id = params['id'];
      })

    this.service.getSelectedProductDetails(this.id).subscribe(
      (productDetails: any) => {
        this.productDetails = productDetails;
        console.log(this.productDetails);
      }
    )  
    this.loadScript("assets/user/js/jquery-3.3.1.min.js");
    this.loadScript("assets/user/js/bootstrap.min.js");
    this.loadScript("assets/user/js/jquery.nice-select.min.js");
    this.loadScript("assets/user/js/jquery-ui.min.js");
    this.loadScript("assets/user/js/jquery.slicknav.js");
    this.loadScript("assets/user/js/mixitup.min.js");
    this.loadScript("assets/user/js/owl.carousel.min.js");
    this.loadScript("assets/user/js/main.js");
  }

  addToCart(id:number, qty:number){
    if(this.authService.customerAuthorization()){
      var data :  any = this.authService.getUserDetails();
      var userId = data["userId"]
      this.service.addProductToCart(id,userId,qty).subscribe((data:{}) => {
        window.alert("Product added to cart successfully");
      });
    }else{
      alert("Please log in to perform this action.")
    }
  }

  public loadScript(url: string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

  

}
