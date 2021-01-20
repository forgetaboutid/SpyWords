using System;
using System.Linq;
using Moq;
using SpyWord.Data;
using SpyWord.Data.Entities;
using Xunit;

namespace SpyWord.Tests
{
    public class GameServiceTests
    {
        private readonly Mock<IGameRepository> _gameRepoMock = new Mock<IGameRepository>();

        public GameServiceTests()
        {
            string[] a = new string[25];
            Array.Fill(a,"word");
            _gameRepoMock.Setup(r => r.GetWords()).Returns(a.ToList);
        }

        [Fact]
        public void GetNewGame_PlayersCountIsOne()
        {
            var sut = new GameService(_gameRepoMock.Object);
            var game = sut.GetNewGame();
            Assert.Single(game.Players);
        }

        [Fact]
        public void GetNewGame_PlayerRoleIsLeader()
        {
            var sut = new GameService(_gameRepoMock.Object);
            var game = sut.GetNewGame();
            Assert.Equal(Role.Leader, game.Players.Single().Role);
        }

        [Fact]
        public void GetNewGame_CallsGetWords()
        {
            var sut = new GameService(_gameRepoMock.Object);
            var game = sut.GetNewGame();
            _gameRepoMock.Verify(r => r.GetWords(), Times.Once);
        }

        [Fact]
        public void JoinGame_GreaterThanOnePlayer()
        {
            _gameRepoMock.Setup(r => r.GetGame(It.IsAny<string>())).Returns(new Game(_gameRepoMock.Object.GetWords()));
            var sut = new GameService(_gameRepoMock.Object);
            var game = sut.JoinGame("");
            Assert.Equal(2, game.Players.Count);
        }

        [Fact]
        public void JoinTeam_GreaterThanOnePlayer()
        {
            Assert.True(false);
        }

    }
}
