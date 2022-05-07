import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin/admin.service';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreateCategoryComponent implements OnInit {

  constructor(public service:AdminService, private fb:FormBuilder, public router:Router) { }

  createCategoryForm = this.fb.group({
    categoryName: ['']
  });

  ngOnInit(): void {
    this.createCategoryForm = new FormGroup(
      {
        categoryName: new FormControl("",[
          Validators.required
        ])
      }
    )
  }

  get categoryName(){
    return this.createCategoryForm.get('categoryName')
  }

  onSubmit(formData:any){
    this.service.postCreateCategory(formData).subscribe((data : any) => {
      window.alert("Category created successfully")
      // this.createCategoryForm.reset
    })
  }

}
