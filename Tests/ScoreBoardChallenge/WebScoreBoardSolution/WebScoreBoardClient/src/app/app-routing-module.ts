import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { App } from '../app/app';
import { LeaderBoardData } from '../leader-board-data/leader-board-data';

const routes: Routes = [
  { path: 'app-root', component: App },
  { path: 'leader-board-data', component: LeaderBoardData } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
