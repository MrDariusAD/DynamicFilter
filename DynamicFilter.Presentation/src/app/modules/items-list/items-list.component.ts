import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/modules/shared/models/Item';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.scss']
})
export class ItemsListComponent implements OnInit {


  public items: Item[];

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getAllItems().subscribe(response => {
      this.items = response
    });
  }

}
