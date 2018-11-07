using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders
{
    public class Die : IDie
    {
        public int Roll()
        {
            var random = new Random();
            return random.Next(1, 6);
        }
    }
}
