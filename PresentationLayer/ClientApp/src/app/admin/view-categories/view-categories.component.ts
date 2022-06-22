import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin/admin.service';

@Component({
  selector: 'app-view-categories',
  templateUrl: './view-categories.component.html',
  styleUrls: ['./view-categories.component.css']
})
export class ViewCategoriesComponent implements OnInit {

  constructor(public service: AdminService, private router:Router) {
  }
  data: [];

  ngOnInit(): void {
    this.loadScript("assets/plugins/jquery/jquery.min.js");
    this.loadCustomScript()
    this.loadScript("assets/plugins/bootstrap/js/bootstrap.bundle.min.js");

    this.service.getCategories().subscribe(
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

  navigate(url:string){
    this.router.navigate(
      [url]
    );
  }
}
