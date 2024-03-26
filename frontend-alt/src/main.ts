import { ApplicationConfig } from '@angular/core';
import { bootstrapApplication, provideProtractorTestingSupport } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';

import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';

const appConfig: ApplicationConfig = {
  providers: [ 
    provideProtractorTestingSupport(), 
    provideRouter(routes) 
  ]
};

bootstrapApplication(AppComponent, appConfig).catch((err) => console.error(err));
