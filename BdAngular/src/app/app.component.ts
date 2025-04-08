import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {ComicListComponent} from "./comic-list/comic-list.component";
import {AddComicComponent} from "./add-comic/add-comic.component";
import {ComicDetailComponent} from "./comic-detail/comic-detail.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ComicListComponent, AddComicComponent, ComicDetailComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'BdAngular';
}
