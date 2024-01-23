import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {ListItem} from "./interfaces/listItem.interface";
import {ListService} from "./services/list.service";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgForOf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent implements OnInit {
  listItems: ListItem[] = [];

  constructor(private listService: ListService) {}

  ngOnInit(): void {
    this.getListItems();
  }

  addItem(description: string) {
    const listItem: ListItem = {
      id: 0,
      description: description,
    };

    this.listService.addListItem(listItem).subscribe({
      next: () => { this.getListItems() },
    });
  }

  deleteItem(id: number) {
    this.listService.deleteListItem(id).subscribe({
      next: () => { this.getListItems() },
    });
  }

  getListItems(): void {
    this.listService.getListItems().subscribe((listItems) => {
      this.listItems = listItems;
    });
  }

}
