using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Dealer : Gamer
    {
        public Dealer()
        {
        }

        public void DealerPlay()
        {
            do
            {
                TakeCard();
                GetCount();
            } while (Sum < 17);
        }
    }
}
