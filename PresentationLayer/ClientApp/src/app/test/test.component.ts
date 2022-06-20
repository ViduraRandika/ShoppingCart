import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AdminService } from '../shared/admin/admin.service';
import { of } from 'rxjs';
import { UserService } from '../shared/user/user.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  progress: number;
  message: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private service: UserService) { 

  }

  ngOnInit(): void {
    this.service.testApi().subscribe((data: {}) => {
        console.log(data)
      });
  }

}

