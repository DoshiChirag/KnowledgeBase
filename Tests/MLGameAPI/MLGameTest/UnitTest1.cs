using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLGameAPI;
using Moq;
using Moq.Language.Flow;
namespace MLGameTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<CGamePublisher> _mock;
        private Guid GameID;
        private GameData Data;
        [TestInitialize]
        public void TestInitialize()
        {
            GameID = Guid.NewGuid();
            Guid PlayerID = Guid.NewGuid();

            IGameReport Report = new CGameReport();
            Data = Report.GetGameStats(GameID, PlayerID);

        }



        [TestMethod]
        public void TestReadGameData()
        {

            string BoxType = string.Empty;
            if (Data.GamePlatform == 1)
                BoxType = "XBox";
            else if (Data.GamePlatform == 2)
                BoxType = "Wii";
            _mock = new Moq.Mock<CGamePublisher>(BoxType);

            GlobalGameData DataObj = new GlobalGameData();
            DataObj.TotalNumberOfPlayers = 2;
            _mock.Setup(m => m.ReadGameDataMethod(It.IsAny<Guid>())).Returns(DataObj);
            

            IGamePublisher target = new CGamePublisher(BoxType);
            DataObj = _mock.Object.ReadGameDataMethod(GameID);
            Assert.AreEqual(DataObj.TotalNumberOfPlayers, target.ReadGameDataMethod(GameID).TotalNumberOfPlayers);
            _mock.Verify(t => t.ReadGameDataMethod(It.Is<Guid>(g => g == GameID)));

        }

    }
}
