import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin/admin.service';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {

  constructor(public service: AdminService) { }

  data: [];

  ngOnInit(): void {
    this.loadScript("assets/plugins/jquery/jquery.min.js");
    this.loadCustomScript()
    this.loadScript("assets/plugins/bootstrap/js/bootstrap.bundle.min.js");

    this.getProducts()
  }

  getProducts() {
    this.service.getProducts().subscribe(
      (data: any) => {
        this.data = data;
      }
    )
  }
  public loadScript(url: string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

  public loadCustomScript() {
    let node = document.createElement('script');
    node.integrity = "$.widget.bridge('uibutton', $.ui.button)"
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

}
