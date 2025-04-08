import {Component, OnInit} from '@angular/core';
import {Comic} from "../comic";
import {ApiService} from "../services/api.service";
import {AddComicComponent} from "../add-comic/add-comic.component";

@Component({
  selector: 'app-comic-list',
  standalone: true,
  imports: [
    AddComicComponent
  ],
  templateUrl: './comic-list.component.html',
  styleUrl: './comic-list.component.css'
})
export class ComicListComponent implements OnInit {
  comics: Comic[] = [];

  constructor(private comicService: ApiService) { }

  ngOnInit(): void {
    this.loadComics();
  }

  loadComics(): void {
    this.comicService.getAllComics().subscribe((data: Comic[]) => {
      this.comics = data;
    });
  }

  onComicAdded(newComic: Comic): void {
    this.comics.push(newComic);  // <-- Add the new comic to the list
  }
}
