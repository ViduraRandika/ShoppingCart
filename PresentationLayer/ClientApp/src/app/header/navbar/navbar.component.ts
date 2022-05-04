import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NavbarComponent implements OnInit {
  faCoffee = faCoffee;
  constructor() { }

  isLoggedin = false;
  
  ngOnInit(): void {
    if(localStorage.getItem("jwt") != null){
      this.isLoggedin = true;
    }
  }

}
