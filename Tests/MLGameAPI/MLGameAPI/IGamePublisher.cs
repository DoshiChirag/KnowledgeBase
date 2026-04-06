using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLGameAPI
{
  public class DelegateTypes
    {
        public delegate GlobalGameData ReadGameData(Guid GameID);
    }

    /// <summary>
    /// Global Game Data Publisher
    /// </summary>
    public interface IGamePublisher
    {
        DelegateTypes.ReadGameData GameEvent { get; set; }
        GlobalGameData ReadGameDataMethod(Guid GameID);
    }
}

//Vendor1

//IGameReport::GetGameStats()
//Stores in Database(GameData)


//Vendor2
//IGamePublisher1.ReadGameDataMethod
//IGamepublisher2.ReadGameDataMethod

//DelegateInitialization
//ReadGameData EventDelegate
//If Publisher == "XBox"
//EventDelegate += GamePulisher1.ReadGameDataMethod
//EventDel.Invoke()



