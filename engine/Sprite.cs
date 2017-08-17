using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TES30
{
    [Serializable]
    public class Sprite
    {
        public char[,] data = new char[8, 8];
        public Sprite()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    data[x, y] = '0';
                }
            }

        }
        public Sprite(char index)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    data[x, y] = index;
                }
            }
        }
        public Sprite(char[,] data)
        {
            this.data = data;
        }
    }
}
