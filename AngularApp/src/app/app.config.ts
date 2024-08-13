import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { IdentityServerModule } from '../modules/identity-server.module';
import { JwTokenInterceptor } from './shared/JwTokenInterceptor';

export const appConfig: ApplicationConfig = {

  providers: [provideRouter(routes),importProvidersFrom(
    HttpClientModule,
    ReactiveFormsModule,
    IdentityServerModule
    ), 
    
    {provide:HTTP_INTERCEPTORS, useClass:JwTokenInterceptor, multi:true},
 // GuardService
  ]

};
