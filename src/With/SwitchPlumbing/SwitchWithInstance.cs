using System;

namespace With.SwitchPlumbing
{
    public class SwitchWithInstance<In, Out> : ISwitchWithInstance<In, Out>
    {
        private readonly ISwitch<In,Out> _switch;
        private readonly In _instance;
        public SwitchWithInstance(In instance, ISwitch<In,Out> @switch)
        {
            _instance = instance;
            _switch = @switch;
        }

        public bool TryMatch(out Out value)
        {
            return _switch.TryMatch(_instance, out value);
        }

        public Out Value()
        {
            return _switch.ValueOf(_instance);
        }

        public ISwitchWithInstance<In, Out> Add(IMatcher<In, Out> m)
        {
            return new SwitchWithInstance<In, Out>(Instance, _switch.Add(m));
        }

        public In Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}

