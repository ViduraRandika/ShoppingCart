import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css']
})
export class AdminLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    // <script>
    //   $.widget.bridge('uibutton', $.ui.button)
    // </script>

    this.loadScript("assets/plugins/jquery/jquery.min.js");
    this.loadScript("assets/plugins/jquery-ui/jquery-ui.min.js");
    this.loadCustomScript()
    this.loadScript("assets/plugins/moment/moment.min.js");
    this.loadScript("assets/plugins/bootstrap/js/bootstrap.bundle.min.js");
    this.loadScript("assets/plugins/chart.js/Chart.min.js");
    this.loadScript("assets/plugins/sparklines/sparkline.js");
    this.loadScript("assets/plugins/jqvmap/jquery.vmap.min.js");
    this.loadScript("assets/plugins/jqvmap/maps/jquery.vmap.usa.js");
    this.loadScript("assets/plugins/jquery-knob/jquery.knob.min.js");
    this.loadScript("assets/plugins/daterangepicker/daterangepicker.js");
    this.loadScript("assets/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js");
    this.loadScript("assets/plugins/summernote/summernote-bs4.min.js");
    this.loadScript("assets/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js");
    this.loadScript("assets/dist/js/adminlte.js");
    this.loadScript("assets/dist/js/pages/dashboard.js");
    // this.loadScript("assets/dist/js/demo.js");
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
