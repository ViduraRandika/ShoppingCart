import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-nav-layout',
  templateUrl: './admin-nav-layout.component.html',
  styleUrls: ['./admin-nav-layout.component.css']
})
export class AdminNavLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.loadScript("assets/plugins/jquery/jquery.min.js");
    this.loadCustomScript()
    this.loadScript("assets/plugins/bootstrap/js/bootstrap.bundle.min.js");
  }

  public loadScript(url:string) {
    let node = document.createElement('script');
    node.src = url;
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }

  public loadCustomScript(){
    let node = document.createElement('script');
    node.integrity="$.widget.bridge('uibutton', $.ui.button)"
    node.type = 'text/javascript';
    document.getElementsByTagName('body')[0].appendChild(node);
  }
}
