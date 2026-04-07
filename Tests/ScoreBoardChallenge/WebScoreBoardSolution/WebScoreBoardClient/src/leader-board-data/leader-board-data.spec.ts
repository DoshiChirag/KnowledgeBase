import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaderBoardData } from './leader-board-data';

describe('LeaderBoardData', () => {
  let component: LeaderBoardData;
  let fixture: ComponentFixture<LeaderBoardData>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LeaderBoardData]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeaderBoardData);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
