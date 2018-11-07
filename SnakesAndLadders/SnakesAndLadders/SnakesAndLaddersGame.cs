using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders
{
    public class SnakesAndLaddersGame
    {
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
            _currentPosition += spacesToMove;
        }
    }
}
