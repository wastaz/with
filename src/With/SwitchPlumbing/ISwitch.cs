namespace With.SwitchPlumbing
{
    public interface IMatchCollector<T, In, Out>
    {
        T Add(IMatcher<In, Out> m);
    }

    public interface ISwitch<In, Out>:IMatchCollector<ISwitch<In,Out>, In,Out>
    {
        bool TryMatch(In instance, out Out value);

        Out ValueOf(In instance);

    }

    public interface ISwitchWithInstance<In, Out>:IMatchCollector<ISwitchWithInstance<In,Out>, In,Out>
    {
        bool TryMatch(out Out value);

        In Instance
        {
            get; 
        }

        Out Value();
    }
}