import { Component, OnInit, signal, inject } from '@angular/core';
import { HttpClient, HttpContext } from '@angular/common/http';
import { App } from '../app/app';
import { AppModule } from '../app/app-module';
import { Router } from '@angular/router';
import { GamePlayer } from '../user-data';

import {

  ActivateEvent,
  ColumnMode,
  DatatableComponent,
  SortType,
  SelectEvent,
  SelectionType,
  TableColumn
} from '@swimlane/ngx-datatable';


@Component({
  selector: 'leader-board-data',
  standalone: false,
  templateUrl: './leader-board-data.html',
  styleUrl: './leader-board-data.css'
})
export class LeaderBoardData implements OnInit {

  protected readonly title = signal('Leader Score Board');
  private jsonData: Object[] | any;
  private jSonDataStr: String | any;
  public playerData: GamePlayer[] | any;
  public tieScoresDataList: GamePlayer[] | any;
  public higherScoresDataList: GamePlayer[] | any;
  public lowerScoresDataList: GamePlayer[] | any;  
  public OverAllRanking: String | any;
 

  columns: TableColumn[] = [
    { prop: 'lastName', name: 'Last Name' },
    { prop: 'firstName', name: 'First Name' },
    { prop: 'score', name: 'Score' },
   

  ];


  constructor(private http: HttpClient, private appParent: App, private navigationRouter: Router) {

    
    
   
  }

  ngOnInit() {

    this.playerData = this.appParent.selectedPlayer;
    this.tieScoresDataList = []
    this.higherScoresDataList = []
    this.lowerScoresDataList = []
    this.OverAllRanking = 0;

    this.http.get("https://localhost:5281/WebScoreBoard/GetPlayersOverallRanking?playerID=" + this.playerData.playerID).subscribe(data => {
      //this.jsonData = data as Object;
      //let obj = Object.assign(this.jsonData);
      this.OverAllRanking = data.toString();
    });


    
    this.http.get("https://localhost:5281/WebScoreBoard/GetPlayersInTie?playerID=" + this.playerData.playerID).subscribe(data => {
      this.jsonData = data as Object[];
      this.convertJSONToGamePlayer(this.jsonData, this.tieScoresDataList);

    });

    this.http.get("https://localhost:5281/WebScoreBoard/GetPlayersWithClosestHigherScores?playerID=" + this.playerData.playerID).subscribe(data => {
      this.jsonData = data as Object[];
      this.convertJSONToGamePlayer(this.jsonData, this.higherScoresDataList);

    });

    this.http.get("https://localhost:5257/WebScoreBoard/GetPlayersWithClosestLowerScores?playerID=" + this.playerData.playerID).subscribe(data => {
      this.jsonData = data as Object[];
      this.convertJSONToGamePlayer(this.jsonData, this.lowerScoresDataList);



    });

  }

  convertJSONToGamePlayer(jsonData: Object[] | any, dataList: GamePlayer[] | any) {

    let n: number = jsonData.length;
    let obj: Object = 0;
    

    for (let i: number = 0; i < n; i++) {
      let obj = Object.assign(new GamePlayer(), jsonData[i]);
      dataList[i] = obj;
    }

   

  }


}
