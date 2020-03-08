import { Component, OnInit, Input } from '@angular/core';
import { Attribute } from 'src/app/modules/shared/models/Attribute';

@Component({
  selector: 'app-attribute-in-card-output',
  templateUrl: './attribute-in-card-output.component.html',
  styleUrls: ['./attribute-in-card-output.component.scss']
})
export class AttributeInCardOutputComponent implements OnInit {

  @Input() attribute: Attribute;
  @Input() isRight = false;
  @Input() isWrong = false;

  constructor() { }

  ngOnInit(): void {
  }

}
