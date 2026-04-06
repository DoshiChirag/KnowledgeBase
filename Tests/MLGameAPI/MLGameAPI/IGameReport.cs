using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLGameAPI
{
    /// <summary>
    /// Game Host- Retireves Game Stats from Database.
    /// </summary>
    public interface IGameReport
    {
        
        GameData GetGameStats(Guid GameID,Guid PlayerID);
        void NavigateReports();
        
        
    }
}
