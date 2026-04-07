import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatButtonModule } from '@angular/material/button'
import { MatInputModule } from '@angular/material/input'
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { provideHttpClient } from "@angular/common/http";

import { LeaderBoardData } from '../leader-board-data/leader-board-data';

@NgModule({
  declarations: [
    App,
    LeaderBoardData
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatInputModule,
    MatButtonModule,
    MatSlideToggleModule,
    MatSelectModule,
    MatTableModule,
    NgxDatatableModule
  ],
  providers: [    
    provideBrowserGlobalErrorListeners(),
    provideHttpClient(),
    
  ],
  bootstrap: [App, LeaderBoardData]
})
export class AppModule { }
