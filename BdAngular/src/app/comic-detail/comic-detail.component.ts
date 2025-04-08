import { Component } from '@angular/core';
import {ApiService} from "../services/api.service";
import {Comic} from "../comic";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-comic-detail',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './comic-detail.component.html',
  styleUrl: './comic-detail.component.css'
})
export class ComicDetailComponent {
  comic: Comic | null = null;
  comicId: number | null = null;
  errorMessage: string | null = null;

  constructor(private apiService: ApiService) {}

  getComic() {
    if (this.comicId) {
      this.apiService.getComicById(this.comicId).subscribe({
        next: (data) => {
          this.comic = data;
          this.errorMessage = null;
        },
        error: (err) => {
          this.comic = null;
          this.errorMessage = 'Comic not found!';
        }
      });
    }
  }
}
