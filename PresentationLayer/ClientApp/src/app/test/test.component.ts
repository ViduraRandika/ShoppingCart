import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AdminService } from '../shared/admin/admin.service';
import { of } from 'rxjs';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  progress: number;
  message: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { 
  }

  ngOnInit(): void {
  }

  fileUp:any;

  uploadFile = (files : any) => {
    if (files.length === 0) {
      return;
    }
    this.fileUp = <File>files[0];
    console.log(this.fileUp.name)
    // const formData = new FormData();
    // formData.append('file', fileToUpload, fileToUpload.name);
    
    // type Product = {
    //   path?: string;
    //   status?: number;
    // };
    // this.http.post('/api/admin/uploadProductImage', formData)
    //   .subscribe((res:Product)=>{
    //     if(res.status = 200){

    //     console.log(res)
    //     console.log(res.hasOwnProperty('path'))
    //     console.log(res.path)
    //     }else{
    //       alert("Something went wrong")
    //     }

        
    //   }
    //   );
  }
}

