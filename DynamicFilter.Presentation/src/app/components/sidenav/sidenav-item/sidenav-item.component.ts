import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidenav-item',
  templateUrl: './sidenav-item.component.html',
  styleUrls: ['./sidenav-item.component.scss']
})
export class SidenavItemComponent implements OnInit {
  @Input() type: 'button' | 'text' = 'button';
  @Input() iconName: string;
  @Input() route: string;
  @Output() clicked = new EventEmitter();

  constructor(private router: Router) { }

  ngOnInit() {
  }
  
  public itemClicked(): void {
    if(this.route) {
      this.router.navigate([this.route]);
    }
    this.clicked.emit();
  }
}
