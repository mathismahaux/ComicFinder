import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Comic} from "../comic";

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:5000/api/BandesDessinees';

  constructor(private http: HttpClient) { }

  getAllComics(): Observable<Comic[]> {
    return this.http.get<Comic[]>(this.apiUrl);
  }

  getComicById(id: number): Observable<Comic> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Comic>(url);
  }

  addComic(comic: Comic): Observable<Comic> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<Comic>(this.apiUrl, comic, httpOptions);
  }
}
