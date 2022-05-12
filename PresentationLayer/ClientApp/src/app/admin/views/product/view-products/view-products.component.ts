import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { AdminService } from 'src/app/shared/admin/admin.service';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {

  constructor(public service:AdminService) { }

  data: [];
  ngOnInit(): void {
    this.getProducts()
  }

  getProducts(){
    this.service.getProducts().subscribe(
      (data:any) => {
        this.data = data;
      }
    )
  }

}
