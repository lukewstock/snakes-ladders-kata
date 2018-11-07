using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders
{
    public class SnakesAndLaddersGame
    {
        private const int boardSize = 100;
        int _currentPosition;
        public event EventHandler GameFinished;

        protected virtual void OnGameFinished(GameFinishedEventArgs e)
        {
            GameFinished?.Invoke(this, e);
        }

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

            if (_currentPosition == boardSize)
            {
                var args = new GameFinishedEventArgs
                {
                    Message = "Player One Wins"
                };

                OnGameFinished(args);
            }
        }

        private bool canMakeMove(int spacesToMove)
        {
            return !(_currentPosition + spacesToMove > boardSize);
        }
    }
}
