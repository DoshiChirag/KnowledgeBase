using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using FolderPath = System.IO.Path;
using SystemFile = System.IO.File;
using System.ComponentModel;
namespace WebScoreBoardAPI.Controllers
{

    public class WebPlayerComparer : IComparer<WebPlayer>
    {
        bool sortAscending = true;
        public WebPlayerComparer(bool sortAsc)
        {
            sortAscending = sortAsc;
        }

        public int Compare(WebPlayer? x, WebPlayer? y)
        {
            if(x == null || y == null)
                return 0;

            if(sortAscending)
            {
                if (x.Score > y.Score) return 1;
                if (x.Score < y.Score) return -1;

            }
            else
            {
               
                if (y.Score > x.Score) return 1;
                if (y.Score < x.Score) return -1;

            }

            return 0;
        }
    }

    [ApiController()]
    [Route("[Controller]/[action]")]
    public class WebScoreBoardController : ControllerBase
    {
        public const string DataDelimiter = ",";
        public const string DataFileName = "player_scores.csv";
        private readonly ILogger<WebScoreBoardController> _logger;
        public static List<WebPlayer>? playersList = new List<WebPlayer>();
        public static  Mutex? lockMutex = new Mutex(false);

        public WebScoreBoardController(ILogger<WebScoreBoardController> logger)
        {
            _logger = logger;
        }

        

        [HttpGet(Name = "{playerListFile}")]
        public IEnumerable<WebPlayer>? GetAllPlayers(string playerListFile = DataFileName)
        {
            try
            {
                string filePath = FolderPath.Combine(Environment.CurrentDirectory, playerListFile);

                if (!SystemFile.Exists(filePath))
                {
                    _logger.LogError($"Players Data File not found at {filePath}");
                    return Enumerable.Empty<WebPlayer>();
                }

                List<WebPlayer>? allPlayers = new List<WebPlayer>();
                IEnumerable<string> dataLines = SystemFile.ReadLines(filePath);

                int numberOfLines = 0;
                foreach (string line in dataLines)
                {
                    ++numberOfLines;
                    if (numberOfLines == 1)
                    {
                        continue;
                    }

                    //Deal with data errors later on.
                    //if any data error then log the error
                    string[] dataColumns = line.Split(DataDelimiter, StringSplitOptions.TrimEntries);

                    int n = 0;
                    Guid guid = Guid.Parse(dataColumns[n++]);
                    string lastName = dataColumns[n++];
                    string firstName = dataColumns[n++];
                    int score = int.Parse(dataColumns[n++]);
                    DateOnly createdOn = DateOnly.ParseExact(dataColumns[n], "MM/dd/yyyy");


                    WebPlayer player = new WebPlayer()
                    {
                        CreatedOn = createdOn,
                        PlayerID = guid,
                        LastName = lastName,
                        FirstName = firstName,
                        Score = score
                    };

                    allPlayers.Add(player);
                }




                //Store the playersList until called again                        
                lockMutex?.WaitOne();
                playersList?.Clear();
                playersList = null;
                playersList = allPlayers;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, playerListFile);

            }
            finally
            {
                lockMutex?.ReleaseMutex();
            }
            return playersList;
        }

        [HttpGet(Name = "{playerID}/{maxNumberOfPlayersToFetch}")]
        public  IEnumerable<WebPlayer>? GetPlayersInTie(string playerID, int maxNumberOfPlayersToFetch = 10)
        {
            lockMutex?.WaitOne();
            List<WebPlayer>? playersInTie = new List<WebPlayer>();

            try
            {
                WebPlayer? player = null;

                player = playersList?.Find(e => e.PlayerID.ToString() == playerID);
                if (player == null)
                {
                    Console.WriteLine($"Player not found with ID = {playerID}");
                    return playersInTie;
                }

                playersInTie = playersList?.FindAll(p => (p.PlayerID.ToString() != player.PlayerID.ToString()) && p.Score == player.Score).Take(10).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, playerID, maxNumberOfPlayersToFetch);
            }
            finally
            {
                lockMutex?.ReleaseMutex();
            }

            return playersInTie;
        }

        [HttpGet(Name = "[[highest]]/{playerID}/{maxNumberOfPlayersToFetch}")]
        public IEnumerable<WebPlayer>? GetPlayersWithClosestHigherScores(string playerID, int maxNumberOfPlayersToFetch = 10)
        {
            lockMutex?.WaitOne();
            List<WebPlayer>? players = new List<WebPlayer>();
            try
            {

                WebPlayer? player = playersList?.Find(e => e.PlayerID.ToString() == playerID);
                if (player == null)
                {
                    Console.WriteLine($"Player not found with ID = {playerID}");
                    return players;
                }

                //Filter for higher scores with first scan of data
                players = playersList?.FindAll(p => (p.PlayerID.ToString() != player.PlayerID.ToString()) && p.Score > player.Score);
                

                //Sort the smaller list of data which is closest to the players score
                players?.Sort(new WebPlayerComparer(true));

            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, playerID, maxNumberOfPlayersToFetch);
            }
            finally
            {
                lockMutex?.ReleaseMutex();
            }
          
            return players?.Take(maxNumberOfPlayersToFetch).ToList();

        }

        [HttpGet(Name = "[[lowest]]{playerID}/{maxNumberOfPlayersToFetch}")]
        public IEnumerable<WebPlayer>? GetPlayersWithClosestLowerScores(string playerID, int maxNumberOfPlayersToFetch = 10)
        {
            lockMutex?.WaitOne();
            List<WebPlayer>? players = new List<WebPlayer>();
            try
            {                
                WebPlayer? player = playersList?.Find(e => e.PlayerID.ToString() == playerID);
                if (player == null)
                {
                    Console.WriteLine($"Player not found with ID = {playerID}");
                    return players;
                }

                //Filter for lower scores with first scan of data
                players = playersList?.FindAll(p => (p.PlayerID.ToString() != player.PlayerID.ToString()) && p.Score < player.Score);

                //Sort the smaller list of data which is closest to the players score
                players?.Sort(new WebPlayerComparer(false));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

            }
            finally
            {
                lockMutex?.ReleaseMutex();
            }

            return players?.Take(maxNumberOfPlayersToFetch).ToList();
        }

        [HttpGet(Name = "{playerID}")]
        public int? GetPlayersOverallRanking(string playerID)
        {
            lockMutex?.WaitOne();

            int? accumulatedRank = 0;

            try
            {
                WebPlayer? player = playersList?.Find(e => e.PlayerID.ToString() == playerID);
                if (player == null)
                {
                    Console.WriteLine($"Player not found with ID = {playerID}");
                    return 0;
                }

                //Group By each score value and then sort the grouped list by each score key            
                List<IGrouping<int, WebPlayer>>? groupedResult = playersList?.GroupBy(p => p.Score).OrderBy(p => p.Key).ToList();

                
                //Count all groups where the score key is greater than players score
                accumulatedRank = groupedResult?.Count(p => p.Key > player.Score);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, playerID);
            }
            finally
            {
                lockMutex?.ReleaseMutex();
            }
            //players score falls in the next rank
            return (accumulatedRank+1);
        }

        
    }
}
