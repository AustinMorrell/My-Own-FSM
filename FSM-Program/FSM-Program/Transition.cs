using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Program
{
    class Transition
    {
        string From;
        string To;

        public Transition(string f, string t)
        {
            From = f;
            To = t;
        }
    }
}
