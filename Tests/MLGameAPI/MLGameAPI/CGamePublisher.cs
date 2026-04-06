using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLGameAPI
{
    public class CGamePublisher : IGamePublisher
    {

        public CGamePublisher(string BoxType)
        {
            GameBoxType = BoxType;
        }

        public CGamePublisher()
        {

        }

        private string _gameBoxType;
        private DelegateTypes.ReadGameData EventDel;

        DelegateTypes.ReadGameData IGamePublisher.GameEvent
        {
            get
            {
                return EventDel;
            }

            set
            {
                EventDel += value;
            }
        }

        public string GameBoxType
        {
            get
            {
                return _gameBoxType;
            }

            set
            {
                _gameBoxType = value;
            }
        }

        //Concrete Implementation of Method
        public virtual GlobalGameData ReadGameDataMethod(Guid GameID)
        {

            if (GameBoxType == "Wii")
            {
                EventDel += ReadXBoxGameDataMethod;
            }
            else if (GameBoxType == "XBox")
                EventDel += ReadWiiGameDataMethod;
            


            System.Console.WriteLine("Game ID = " + GameID.ToString());

            return EventDel.Invoke(GameID);

        }

        /// <summary>
        /// XBox Method
        /// </summary>
        /// <param name="GameID"></param>
        /// <returns></returns>
        public GlobalGameData ReadXBoxGameDataMethod(Guid GameID)
        {
            System.Console.WriteLine("Game ID = "+GameID.ToString());
            //some web service that returns global game data for XBox
            GlobalGameData Data = new GlobalGameData();
            Data.TotalNumberOfPlayers = 2;
            Data.totalPointsScored = 15460;
            Data.Level = new int[] { 4, 2 };    
            return Data;
            
        }

        /// <summary>
        /// Wii Method
        /// </summary>
        /// <param name="GameID"></param>
        /// <returns></returns>
        public GlobalGameData ReadWiiGameDataMethod(Guid GameID)
        {
            System.Console.WriteLine("Game ID = " + GameID.ToString());
            //some webservice that returns Global Game data
            GlobalGameData Data = new GlobalGameData();
            Data.TotalNumberOfPlayers = 2;
            Data.totalPointsScored = 13425;
            Data.Level = new int[] { 1, 2 };
            return Data;

        }

    }
}
