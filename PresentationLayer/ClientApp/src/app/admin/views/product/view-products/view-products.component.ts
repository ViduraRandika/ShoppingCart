import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ViewProductsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
