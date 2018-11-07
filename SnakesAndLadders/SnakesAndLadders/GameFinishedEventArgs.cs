using System;

namespace SnakesAndLadders
{
    public class GameFinishedEventArgs :EventArgs
    {
        public string Message { get; set; }
    }
}