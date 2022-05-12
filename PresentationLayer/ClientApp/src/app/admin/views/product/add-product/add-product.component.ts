import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin/admin.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  
  form: FormGroup;

  constructor(public service:AdminService, private fb:FormBuilder, public router:Router) {}

  data:[];
  fileToUpload:any;

  addProductForm = this.fb.group({
    productName: [''],
    description:[''],
    selectCategory:[''],
    price:[''],
    productImagePath:['']
  })
  ngOnInit(): void {
    this.service.getCategories().subscribe(
      (data: any) => {
        this.data = data;
      }
    )

    this.addProductForm = new FormGroup({
      productName: new FormControl("", [
        Validators.required
      ]),
      description: new FormControl("", [
        Validators.required
      ]),
      selectCategory: new FormControl("", [
        Validators.required
      ]),
      price: new FormControl("", [
        Validators.required
      ]),
      productImagePath: new FormControl("", [
        Validators.required
      ])
    })
  }

  uploadFile = (files : any) => {
      if (files.length === 0) {
        return;
      }
      this.fileToUpload =  <File>files[0];
    }

  submit(form: any){
    const formData = new FormData();
    formData.append('file', this.fileToUpload, this.fileToUpload.name);
    
    type Product = {
      path?: string;
      status?: number;
    };
    this.service.uploadImg(formData)
      .subscribe((res:Product)=>{
        if(res.status = 200){
          this.submitFormData(form,res.path);
        }else{
          alert("Something went wrong")
        }

        
      }
    );
  }

  submitFormData(form:any, path:any){
    var data = {
      description: form.description,
      price: form.price,
      productImagePath: path,
      productName: form.productName,
      CategoryId: form.selectCategory,
    }

    this.service.postAddProduct(data)
      .subscribe((res)=>{
        window.alert("Product added successfullty");
      })

  }

}
