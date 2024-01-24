import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {ListItem} from "../interfaces/listItem.interface";

@Injectable({
  providedIn: 'root',
})
export class ListService {
  private baseUrl = 'http://localhost:5010/api';

  constructor(private http: HttpClient) {}

  getListItems(): Observable<ListItem[]> {
    return this.http.get<ListItem[]>(`${this.baseUrl}/ListItem`);
  }

  getListItem(id: number): Observable<ListItem> {
    return this.http.get<ListItem>(`${this.baseUrl}/ListItem/${id}`);
  }

  addListItem(model: ListItem): Observable<ListItem> {
    return this.http.post<ListItem>(`${this.baseUrl}/ListItem`, model);
  }

  updateListItem(model: ListItem): Observable<ListItem> {
    return this.http.put<ListItem>(`${this.baseUrl}/ListItem`, model);
  }

  deleteListItem(id: number): Observable<ListItem> {
    return this.http.delete<ListItem>(`${this.baseUrl}/ListItem/${id}`);
  }
}

