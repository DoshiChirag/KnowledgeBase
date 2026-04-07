import { Component, OnInit, signal, inject } from '@angular/core';
import { HttpClient, HttpContext } from '@angular/common/http';
import { NavigationEnd, Router } from '@angular/router';
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
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'  
})
export class App implements OnInit {
  protected readonly title = signal('Welcome to Game Score Board');
  public showComponent: boolean = true;
  private jsonData: Object[] | any;
  private jSonDataStr: String | any;
  public dataList: GamePlayer[] | any;
  public selectedPlayer: GamePlayer | any;
  public ColumnMode : ColumnMode | any;
  public SelectionType : SelectionType | any;
  public OverAllRanking: Number | any;
  columns: TableColumn[] = [
    { prop: 'lastName', name: 'Last Name' },
    { prop: 'firstName', name: 'First Name' },
    { prop: 'score', name: 'Score' },
    { prop: 'createdOn', name: 'Created On' },
    { prop: 'playerID', name: 'Player GUID' }

  ];

 

  
  

  

  constructor(private http: HttpClient, private navigationRouter: Router) {
    navigationRouter.events.subscribe((e) => {
      if (e instanceof NavigationEnd) {
        if (e.url == '/') {
          this.showComponent = true;
        }
        else {
          this.showComponent = false;
        }
      }
    });
  }

  ngOnInit() {
    
    return this.http.get("https://localhost:5281/WebScoreBoard/GetAllPlayers?playerListFile=player_scores.csv").subscribe(data => {
      this.jsonData = data as Object[];
      this.convertJSONToGamePlayer(this.jsonData);

    });  
  }

  convertJSONToGamePlayer(jsonData: Object[] | any) {

    let n: number = jsonData.length;
    let obj: Object = 0;
    this.dataList = [];
   
    for (let i: number = 0; i < n; i++)
    {
      let obj = Object.assign(new GamePlayer(), jsonData[i]);
      this.dataList[i] = obj;
    }

    

  }

  onChange(event: GamePlayer | any) {
    this.selectedPlayer = event.value;
    console.log('Selected Player ID:', this.selectedPlayer.playerID);
    console.log('Selected Player First Name:', this.selectedPlayer.firstName);
    console.log('Selected Player Last Name:', this.selectedPlayer.lastName);
    console.log('Selected Player Score:', this.selectedPlayer.score);
    console.log('Selected Player Created On:', this.selectedPlayer.createdOn);



    this.navigationRouter.navigate(['leader-board-data']);


  }

  onSelect(selected: SelectEvent<GamePlayer> | any) {
    console.log('Select Event', selected, this.selectedPlayer);
    
    this.http.get("https://localhost:5281/WebScoreBoard/GetPlayersOverallRanking/playerID=" + this.selectedPlayer.playerID).subscribe(data => {
      this.jsonData = data as Object[];
      let obj = Object.assign(new Number(), this.jsonData[0]);
      this.OverAllRanking = obj;
    });


  }

  onActivate(event: ActivateEvent<GamePlayer> | any) {
    console.log('Activate Event', event);
  }


}
