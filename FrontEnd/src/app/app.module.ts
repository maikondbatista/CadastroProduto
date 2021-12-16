import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxLoadingModule } from 'ngx-loading';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConfigService, LoadConfigJson } from './shared/services/config.service';
import { SharedModule } from './shared/shared-module/shared-module.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    AppRoutingModule,
    SharedModule.forRoot(),
    BrowserAnimationsModule,
    NgxLoadingModule.forRoot({}),
  ],
  providers: [
    { provide: APP_INITIALIZER, useFactory: LoadConfigJson, deps: [ConfigService], multi: true },

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
