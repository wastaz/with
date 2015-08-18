using System;
using With.SwitchPlumbing;

namespace With
{
    public static class TypeSwitchExtensions
    {
        public static ISwitch<In, Out> Case<On, In, Out>(
            this ISwitch<In, Out> that, Func<On, Out> func)
            where On : In
        {
            return that.Add(new MatchType<On, In, Out>(func));
        }
    }
}
