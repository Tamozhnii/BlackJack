using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBlackJack;

namespace BlackJack
{
    class Service : BlackJack, IContract
    {
        public string IMoreCard(bool b)
        {
            return MoreCard(b);
        }

        public string IPlay()
        {
            BlackJack blackJack = new BlackJack();
            return blackJack.Play();
        }

        public string[][] IStat()
        {
            return Stat();
        }

        public void IReplay(bool b)
        {
            Replay(b);
        }

        public void IExit()
        {
            Exit(this as BlackJack);
        }
    }
}
