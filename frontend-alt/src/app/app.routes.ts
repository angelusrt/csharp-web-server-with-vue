import { Routes } from '@angular/router';
import { HomeView } from './view/homeView.component';
import { AboutView } from './view/aboutView.component';

export const routes: Routes = [
  { path: "", component: HomeView, },
  { path: "about", component: AboutView, },
];
