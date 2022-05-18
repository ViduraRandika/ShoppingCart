import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminService } from 'src/app/shared/admin/admin.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  form: FormGroup;

  constructor(public service: AdminService, private fb: FormBuilder) { }

  data: [];
  fileToUpload: any;

  addProductForm = this.fb.group({
    productName: [''],
    description: [''],
    selectCategory: [''],
    price: [''],
    productImagePath: ['']
  })


  ngOnInit(): void {
    this.loadScript("assets/plugins/jquery/jquery.min.js");
    this.loadCustomScript()
    this.loadScript("assets/plugins/bootstrap/js/bootstrap.bundle.min.js");

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

  get productName() {
    return this.addProductForm.get('productName')
  }

  get description() {
    return this.addProductForm.get('description')
  }

  get selectCategory() {
    return this.addProductForm.get('selectCategory')
  }

  get price() {
    return this.addProductForm.get('price')
  }

  get productImagePath() {
    return this.addProductForm.get('productImagePath')
  }

  uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }
    this.fileToUpload = <File>files[0];
  }

  submit(form: any) {
    const formData = new FormData();
    formData.append('file', this.fileToUpload, this.fileToUpload.name);

    type Product = {
      path?: string;
      status?: number;
    };
    this.service.uploadImg(formData)
      .subscribe((res: Product) => {
        if (res.status = 200) {
          this.submitFormData(form, res.path);
        } else {
          alert("Something went wrong")
        }


      }
      );
  }

  submitFormData(form: any, path: any) {
    var data = {
      description: form.description,
      price: form.price,
      productImagePath: path,
      productName: form.productName,
      CategoryId: form.selectCategory,
    }

    this.service.postAddProduct(data)
      .subscribe((res) => {
        window.alert("Product added successfullty");
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
}
