namespace With.SwitchPlumbing
{
    public interface ISwitch<In, Out>
    {
        bool TryMatch(out Out value);

        In Instance
        {
            get; set;
        }

        Out ValueOf(In instance);

        ISwitch<In, Out> Add(IMatcher<In, Out> m);
    }
}