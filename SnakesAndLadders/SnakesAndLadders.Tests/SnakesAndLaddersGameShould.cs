using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

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
        public void ShouldUpdateTheCurrentPlayerTokenPosition_WhenATurnIsTaken(int moves, int expectedPosition)
        {
            _mockDie.Setup(x => x.Roll()).Returns(moves);
            _game.TakeTurn();

            var result = _game.GetPlayerTokenPosition();
            result.Should().Be(expectedPosition);
        }

        [Test]
        public void ShouldUpdateThePositionForEachMove_WhenTurnTakenMutipleTimes()
        {
            _mockDie.Setup(x => x.Roll()).Returns(5);

            _game.TakeTurn();
            _game.TakeTurn();

            var result = _game.GetPlayerTokenPosition();
            result.Should().Be(11);
        }

        [Test]
        public void ShouldNotUpdateThePosition_WhenTheTurnWouldExceedTheMaxPosition()
        {
            _mockDie.Setup(x => x.Roll()).Returns(100);

            _game.TakeTurn();

            var result = _game.GetPlayerTokenPosition();
            result.Should().Be(1);
        }

        [Test]
        public void ShouldFinishTheGame_WhenThePlayerTokenReachesTheLastSqaureTakingATurn()
        {
            string result = string.Empty;

            _game.GameFinished += delegate (object sender, EventArgs e)
            {
                var eventData = (GameFinishedEventArgs)e;
                result = eventData.Message;
            };

            _mockDie.Setup(x => x.Roll()).Returns(99);
            _game.TakeTurn();

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