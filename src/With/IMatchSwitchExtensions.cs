using With.SwitchPlumbing;
using System;
using System.Collections.Generic;

namespace With
{
    public static class IMatchSwitchExtensions
    {
        // 
        public static T Case<T, In, NothingOrPrepared>(this MatchCollector<T, In, NothingOrPrepared> that,
            In expected, Action<In> result)
        {
            return that.Add(new MatchSingle<In, NothingOrPrepared>(
                expected,
                F.ReturnDefault<In, NothingOrPrepared>(result)));
        }

        public static T Case<T, In, NothingOrPrepared>(this MatchCollector<T, In, NothingOrPrepared> that,
            In expected, Action result)
        {
            return that.Add(new MatchSingle<In, NothingOrPrepared>(
                expected,
                F.ReturnDefault<In, NothingOrPrepared>(F.IgnoreInput<In>(result))));
        }

        public static T Case<T, In, NothingOrPrepared>(this MatchCollector<T, In, NothingOrPrepared> that,
            IEnumerable<In> expected, Action<In> result)
        {
            return that.Add( new Match<In, NothingOrPrepared>(
                expected,
                F.ReturnDefault<In, NothingOrPrepared>(result)));
        }

        public static T Case<T, In, NothingOrPrepared>(this MatchCollector<T, In, NothingOrPrepared> that,
            IEnumerable<In> expected, Action result)
        {
            return that.Add(new Match<In, NothingOrPrepared>(
                expected,
                F.ReturnDefault<In, NothingOrPrepared>(F.IgnoreInput<In>(result))));
        }


        public static T Case<T, In, NothingOrPrepared>(this MatchCollector<T, In, NothingOrPrepared> that,
            Func<In, bool> expected, Action<In> result)
        {
            return that.Add(new Match<In, NothingOrPrepared>(
                expected,
                F.ReturnDefault<In, NothingOrPrepared>(result)));
        }
        public static T Case<T, In, NothingOrPrepared>(this MatchCollector<T, In, NothingOrPrepared> that,
            Func<In, bool> expected, Action result)
        {
            return that.Add(new Match<In, NothingOrPrepared>(
                expected,
                F.ReturnDefault<In, NothingOrPrepared>(F.IgnoreInput<In>(result))));
        }


        public static void Else<In>(this SwitchWithInstance<In, Nothing> that,
            Action<In> result)
        {
            var els = that.Add(new MatchElse<In, Nothing>(
                F.ReturnDefault<In, Nothing>(result)));
            Nothing value;
            els.TryMatch(out value);
        }

        public static void ElseFail<In>(this SwitchWithInstance<In, Nothing> that)
        {
            that.ElseFailWith(@in => new Exception("Failed to match"));
        }

        public static void ElseFailWith<In>(this SwitchWithInstance<In, Nothing> that, Func<In,Exception> generator)
        {
            var els = that.Add(new MatchElse<In, Nothing>(
                F.ReturnDefault<In, Nothing>(@in=> { throw generator(@in); })));
            Nothing value;
            els.TryMatch(out value);
        }

        public static T Else<T, In>(this MatchCollector<T, In, Prepared> that,
            Action<In> result)
        {
            return that.Add(new MatchElse<In, Prepared>(
                F.ReturnDefault<In, Prepared>(result)));
        }


        public static Out Result<In, Out>(this SwitchWithInstance<In, Out> that)
        {
            return that.Value();
        }
    }
}
