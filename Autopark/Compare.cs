using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class Comparer: IComparer<Venicle>
    {
        public int Compare(Venicle x, Venicle y)
        {
            var venicleX = x.ModelName.ToCharArray();
            int firsLetterX = venicleX[0];
            var venicleY = y.ModelName.ToCharArray();
            int firsLetterY = venicleY[0];

            if (firsLetterX < firsLetterY)
            {
                return 1;
            }

            if (firsLetterX > firsLetterY)
            {
                return -1;
            }

            return 0;
        }
    }
}
