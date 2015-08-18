using System.Collections.Generic;
using System.Linq;
using System;


namespace With.SwitchPlumbing
{
    public class Switch<In, Out> : ISwitch<In, Out>
    {
        private readonly IMatcher<In, Out>[] matchers=new IMatcher<In, Out>[0];
        public Switch()
        {
        }
        private Switch(IMatcher<In,Out> matcher, IMatcher<In,Out>[] matchers)
        {
            if (matchers == null)
            {
                throw new ArgumentException("missing matchers!");
            }
            this.matchers = matchers.ToList()
                .Tap(l=>l.Add(matcher))
                .ToArray();// copy and add
        }

        public bool TryMatch(out Out value)
        {
            for (int i =  0; i < matchers.Length; i++)
            {
                Out tryValue;
                if (matchers[i].TryMatch(Instance, out tryValue))
                {
                    value = tryValue;
                    return true;
                }
            }
            value = default(Out);
            return false;
        }

        public In Instance
        {
            get;
            set;
        }

        public ISwitch<In, Out> Add(IMatcher<In, Out> m)
        {
            return new Switch<In, Out>(m, this.matchers);
        }

        public Out ValueOf(In instance)
        {
            this.Instance = instance;
            Out value;
            if (TryMatch(out value))
                return value;
            throw new NoMatchFoundException();
        }

        public static implicit operator Out(Switch<In, Out> d)
        {
            Out value;
            if (d.TryMatch(out value))
                return value;
            throw new NoMatchFoundException();
        }
    }
}