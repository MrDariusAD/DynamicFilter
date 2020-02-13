import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styles: []
})
export class AppComponent {
  title = 'DynamicFilter-Presentation';
  
  constructor(r: Router) {
    console.log(r.routerState);
  }
}
