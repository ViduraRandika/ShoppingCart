import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth/auth.service';
import { UserService } from 'src/app/shared/user/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private service:UserService, private router:Router, private authService:AuthService) { }

  products:[];
  categories:[];
  userData:{};
  ngOnInit(): void {
    this.service.getCategories().subscribe(
      (categories:any)=>{
        this.categories = categories;
      }
    )

    this.getAllProducts();
    this.loadScript("assets/user/js/jquery-3.3.1.min.js");
    this.loadScript("assets/user/js/bootstrap.min.js");
    this.loadScript("assets/user/js/jquery.nice-select.min.js");
    this.loadScript("assets/user/js/jquery-ui.min.js");
    this.loadScript("assets/user/js/jquery.slicknav.js");
    this.loadScript("assets/user/js/mixitup.min.js");
    this.loadScript("assets/user/js/owl.carousel.min.js");
    this.loadScript("assets/user/js/main.js");

  }

  goToProduct(id:number){
    this.router.navigate(
      ['user/shop/product-details'],
      {queryParams: {id: id}}
    );
  }
  
  getSelectedCategoryProducts(id:number){
    this.service.getSelectedCategoryProducts(id).subscribe(
      (products:any)=>{
        this.products = products;
      }
    )
  }

  getAllProducts(){
    this.service.getProducts().subscribe(
      (products:any) => {
        this.products = products;
      }
    )
  }

  addToCart(id:number){
    if(this.authService.customerAuthorization()){
      this.service.addProductToCart(id,1).subscribe((data:{}) => {
        const Toast = Swal.mixin({
          toast: true,
          position: 'top-end',
          showConfirmButton: false,
          timer: 3000,
          timerProgressBar: true,
          didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
          }
        })

        Toast.fire({
          icon: 'success',
          title: 'Product added to cart successfully'
        })
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
