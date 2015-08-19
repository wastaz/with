using With.SwitchPlumbing;

namespace With
{
    public static partial class Switch
    {
        public static ISwitchWithInstance<In, Nothing> Match<In>(In value)
        {
            return new SwitchWithInstance<In,Nothing>(value, new Switch<In, Nothing>());
        }
        public static ISwitchWithInstance<In, Nothing> On<In>(In value)
        {
            return new SwitchWithInstance<In,Nothing>(value, new Switch<In, Nothing>());
        }

        public static ISwitchWithInstance<In, Out> Match<In, Out>(In value)
        {
            return new SwitchWithInstance<In,Out>(value, new Switch<In, Out>());
        }
        public static ISwitchWithInstance<In, Out> On<In, Out>(In value)
        {
            return new SwitchWithInstance<In,Out>(value, new Switch<In, Out>());
        }

        public static ISwitch<In, Prepared> Match<In>()
        {
            return new Switch<In, Prepared>();
        }
        public static ISwitch<In, Prepared> On<In>()
        {
            return new Switch<In, Prepared>();
        }

        public static ISwitch<In, Out> Match<In, Out>()
        {
            return new Switch<In, Out>();
        }
        public static ISwitch<In, Out> On<In, Out>()
        {
            return new Switch<In, Out>();
        }
    }
}
