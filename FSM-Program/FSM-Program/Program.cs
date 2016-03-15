using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Program
{
    class Program
    {
       static void Main(string[] args)
        {
            string Input = "";
            FSM fsm = new FSM(FSM.MyState.init.ToString());
            fsm.AddState(FSM.MyState.init.ToString(), FSM.From_init);
            fsm.AddState(FSM.MyState.idle.ToString(), FSM.From_idle);
            fsm.AddState(FSM.MyState.walk.ToString(), FSM.From_walk);
            fsm.AddState(FSM.MyState.run.ToString(), FSM.From_run);

            while (true)
            {
                fsm.info();
                Input = Console.ReadLine();

                switch (Input)
                {
                    case "a":
                        fsm.ChangeState("Idle");
                        break;

                    case "s":
                        fsm.ChangeState("Walk");
                        break;

                    case "d":
                        fsm.ChangeState("Run");
                        break;
                }
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}
