import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'ClientApp';

  constructor(
    private router: Router,
    private titleService: Title,
  ) {
    titleService.setTitle(this.title);
  }
  
}
