using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyClicker.Model
{
    class GetRandomKey
    {
        private static readonly char[] _keys = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static Random random = new Random();

        public static char GetRandomEnglishLetter()
        {
            return _keys[random.Next(_keys.Length)];
        }
    }
}
