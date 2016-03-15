using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Program
{
    class FSM
    {
        public enum MyState
        {
            init,
            idle,
            walk,
            run,
        }

        Transition To_idle = new Transition(MyState.init.ToString(), MyState.idle.ToString());
        Transition To_idle2 = new Transition(MyState.walk.ToString(), MyState.idle.ToString());
        Transition To_idle3 = new Transition(MyState.run.ToString(), MyState.idle.ToString());
        Transition To_walk = new Transition(MyState.idle.ToString(), MyState.walk.ToString());
        Transition To_walk2 = new Transition(MyState.run.ToString(), MyState.walk.ToString());
        Transition To_run = new Transition(MyState.walk.ToString(), MyState.run.ToString());
        Transition To_run2 = new Transition(MyState.idle.ToString(), MyState.run.ToString());

        public static List<Transition> From_init;
        public static List<Transition> From_idle;
        public static List<Transition> From_walk;
        public static List<Transition> From_run;

        Dictionary<string, List<Transition>> TransitionTable = new Dictionary<string, List<Transition>>();
        private List<string> _states = new List<string>();

        string _currentState;

        public FSM(string initial)
        {
            _currentState = initial;
            From_init = new List<Transition>(new Transition[] { To_idle });
            From_idle = new List<Transition>(new Transition[] { To_walk, To_run2 });
            From_walk = new List<Transition>(new Transition[] { To_idle2, To_run });
            From_run = new List<Transition>(new Transition[] { To_walk2, To_idle3 });
        }

        public bool AddState(string state, List<Transition> a)
        {
            if (_states.Contains(state))
            {
                Console.WriteLine("Nope");
                return false;
            }
            else
            {
                _states.Add(state);
                TransitionTable.Add(state, a);
                return true;
            }
        }

        public void info()
        {
            Console.WriteLine("FSM is comprised of...");
            int count = 0;
            foreach (string a in _states)
            {
                Console.WriteLine("State " + count.ToString() + ": " + a.ToString());
                count++;
            }
            Console.WriteLine("State: " + _currentState);
        }

        public void ChangeState(string delta)
        {
            switch (delta)
            {
                case "Idle":
                    if (TransitionTable[_currentState].Contains(To_idle) || TransitionTable[_currentState].Contains(To_idle2))
                    {
                        _currentState = "idle";
                    }
                    break;

                case "Walk":
                    if (TransitionTable[_currentState].Contains(To_walk) || TransitionTable[_currentState].Contains(To_walk2))
                    {
                        _currentState = "walk";
                    }
                    break;

                case "Run":
                    if (TransitionTable[_currentState].Contains(To_run) || TransitionTable[_currentState].Contains(To_run2))
                    {
                        _currentState = "run";
                    }
                    break;
            }
        }
    }
}
