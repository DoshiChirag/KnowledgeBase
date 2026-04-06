using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLGameAPI
{
    public class CGameReport : IGameReport
    {
        public GameData GetGameStats(Guid GameID, Guid PlayerID)
        {
            GameData Data = new GameData();
            Data.GamePoints = 100;
            Data.GamePlatform = 1;
            Data.NumberofPlayedTurns = 15;
            Data.PlayerName = "ML";
            Data.TotalPoints = 10000;
            Data.LevelAchieved = 6;
            return Data;
            
        }

        public void NavigateReports()
        {
            throw new NotImplementedException();
        }
    }
}
