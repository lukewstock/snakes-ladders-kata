using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders
{
    public class SnakesAndLaddersGame
    {
        private const int boardSize = 100;
        int _currentPosition;

        public SnakesAndLaddersGame()
        {
            _currentPosition = 1;
        }

        public int GetPlayerTokenPosition()
        {
            return _currentPosition;
        }

        public void MoveToken(int spacesToMove)
        {
            if (canMakeMove(spacesToMove))
            {
                _currentPosition += spacesToMove;
            }
        }

        private bool canMakeMove(int spacesToMove)
        {
            return !(_currentPosition + spacesToMove > boardSize);
        }
    }
}
