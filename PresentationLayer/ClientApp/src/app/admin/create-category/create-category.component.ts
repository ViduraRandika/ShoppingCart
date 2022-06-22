import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin/admin.service';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})
export class CreateCategoryComponent implements OnInit {

  constructor(public service: AdminService, private fb: FormBuilder, private router:Router) { }

  createCategoryForm = this.fb.group({
    categoryName: ['']
  });

  ngOnInit(): void {
    this.loadScript("assets/plugins/jquery/jquery.min.js");
    this.loadCustomScript()
    this.loadScript("assets/plugins/bootstrap/js/bootstrap.bundle.min.js");

    this.createCategoryForm = new FormGroup(
      {
        categoryName: new FormControl("", [
          Validators.required
        ])
      }
    )
  }

  get categoryName() {
    return this.createCategoryForm.get('categoryName')
  }

  onSubmit(formData: any) {
    this.service.postCreateCategory(formData).subscribe((data: any) => {
      window.alert("Category created successfully")
      // this.createCategoryForm.reset
    })
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
