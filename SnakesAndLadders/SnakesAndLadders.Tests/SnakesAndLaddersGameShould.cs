using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders.Tests
{
    [TestFixture]
    public class SnakesAndLaddersGameShould
    {
        private SnakesAndLaddersGame _game;
        private Mock<IDie> _mockDie;

        [SetUp]
        public void SetUp()
        {
            _mockDie = new Mock<IDie>();
            _game = new SnakesAndLaddersGame(_mockDie.Object);
        }

        [Test]
        public void InitialiseThePlayerTokenInPositionOne_WhenTheGameIsStarted()
        {
            int result = _game.GetPlayerTokenPosition();

            result.Should().Be(1);
        }

        [TestCase(1, 2)]
        [TestCase(24, 25)]        
        public void ShouldUpdateTheCurrentPlayerTokenPosition_WhenPlayerTokenIsMoved(int moves, int expectedPosition)
        {
            _game.MoveToken(moves);

            var result = _game.GetPlayerTokenPosition();
            result.Should().Be(expectedPosition);
        }

        [Test]
        public void ShouldUpdateThePositionForEachMove_WhenPlayerTokenIsMovedMutipleTimes()
        {
            _game.MoveToken(1);
            _game.MoveToken(7);

            var result = _game.GetPlayerTokenPosition();
            result.Should().Be(9);
        }

        [Test]
        public void ShouldNotUpdateThePosition_WhenTheMoveWouldExceedTheMaxPosition()
        {
            _game.MoveToken(100);

            var result = _game.GetPlayerTokenPosition();
            result.Should().Be(1);
        }

        [Test]
        public void ShouldFinishTheGame_WhenThePlayerTokenReachesTheLastSqaure()
        {
            string result = string.Empty;

            _game.GameFinished += delegate (object sender, EventArgs e)
            {
                var eventData = (GameFinishedEventArgs)e;
                result = eventData.Message;
            };

            _game.MoveToken(99);

            result.Should().BeEquivalentTo("Player One Wins");
        }

        [Test]
        public void ShouldRollTheDie_WhenTakingATurn()
        {
            _mockDie.Setup(x => x.Roll()).Returns(1);

            _game.TakeTurn();

            _mockDie.Verify(x => x.Roll(), Times.Once);
        }
    }
}