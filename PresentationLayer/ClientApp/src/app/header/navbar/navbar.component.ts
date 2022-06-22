import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Router } from '@angular/router';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NavbarComponent implements OnInit {
  faCoffee = faCoffee;
  constructor(private router:Router) { }

  isLoggedin = false;
  
  ngOnInit(): void {
    if(localStorage.getItem("jwt") != null){
      this.isLoggedin = true;
    }
  }

  navigate(url:string){
    this.router.navigate(
      [url]
    );
  }

}
