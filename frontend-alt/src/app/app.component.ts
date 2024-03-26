import { Component } from '@angular/core';
import { RouterOutlet, RouterLink, RouterModule } from '@angular/router';
import { HomeView } from './view/homeView.component';
import { AboutView } from './view/aboutView.component';
import { VoteEl } from './components/voteEl.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, RouterOutlet, RouterLink, HomeView, AboutView, VoteEl],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend-alt';
}
