using FluentAssertions;
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

        [SetUp]
        public void SetUp()
        {
            _game = new SnakesAndLaddersGame();
        }

        [Test]
        public void InitialiseThePlayerTokenInPositionOne_WhenTheGameIsStarted()
        {
            int result = _game.GetPlayerTokenPosition();

            result.Should().Be(1);
        }

        [TestCase(1, 2)]
        [TestCase(24, 25)]
        [TestCase(2091, 2092)]
        public void ShouldUpdateTheCurrentPlayerTokenPosition_WhenPlayerTokenIsMoved(int moves, int expectedPosition)
        {
            _game.MoveToken(moves);

            var result = _game.GetPlayerTokenPosition();
            result.Should().Be(expectedPosition);
        }
    }
}