import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { AdminService } from 'src/app/shared/admin/admin.service';

@Component({
  selector: 'app-view-categories',
  templateUrl: './view-categories.component.html',
  styleUrls: ['./view-categories.component.css']
})
export class ViewCategoriesComponent implements OnInit {
  constructor(public service:AdminService) { 
  }
  data:[];

  ngOnInit(): void {
    this.service.getCategories().subscribe(
      (data: any) => {
        this.data = data;

        for(var i=0; i<data.length; i++){
          console.log(data[i]['categoryId'])
          console.log(data[i]['categoryName'])
        }
      }
    )

  }

}
