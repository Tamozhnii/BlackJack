using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBlackJack;

namespace BlackJack
{
    class Service : IContract
    {
        public string Answer(string x)
        {
            return x;
        }

        //public string Play()
        //{
        //    BlackJack blackJack = new BlackJack();
        //    return blackJack.Play();
        //}
    }
}
