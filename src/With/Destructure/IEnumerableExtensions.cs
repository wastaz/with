﻿using System;
using System.Collections.Generic;
using System.Linq;
using With.Linq;

namespace With.Destructure
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Let<T>(
            this IEnumerable<T> that, Action<T, IEnumerable<T>> action)
        {
            var e = that.GetEnumerator();
            var rest = e.Yield();
            action(e.GetNext(), rest);
            return rest;
        }

        public static IEnumerator<T> Let<T>(
            this IEnumerator<T> that, Action<T> action)
        {
            action(that.GetNext());
            return that;
        }

        public static TRet Let<T, TRet>(
            this IEnumerable<T> that, Func<T, IEnumerable<T>, TRet> func)
        {
            var e = that.GetEnumerator();
            return func(e.GetNext(), e.Yield());
        }

        public static TRet Let<T, TRet>(
            this IEnumerator<T> that, Func<T, TRet> func)
        {
            return func(that.GetNext());
        }

        public static IEnumerable<T> Let<T>(
            this IEnumerable<T> that, Action<T, T, IEnumerable<T>> action)
        {
            var e = that.GetEnumerator();
            var rest = e.Yield();
            action(e.GetNext(), e.GetNext(), rest);
            return e.Yield();
        }

        public static IEnumerator<T> Let<T>(
            this IEnumerator<T> that, Action<T, T> action)
        {
            action(that.GetNext(), that.GetNext());
            return that;
        }

        public static TRet Let<T, TRet>(
            this IEnumerable<T> that, Func<T, T, IEnumerable<T>, TRet> func)
        {
            var e = that.GetEnumerator();
            return func(e.GetNext(), e.GetNext(), e.Yield());
        }

        public static TRet Let<T, TRet>(
            this IEnumerator<T> that, Func<T, T, TRet> func)
        {
            return func(that.GetNext(), that.GetNext());
        }

        [Obsolete("Use pairwise")]
        public static void Stitch<T>(
            this IEnumerable<T> self, Action<T, T> action, Action<T> onLast = null)
        {
            var enumerator = self.GetEnumerator();
            enumerator.MoveNext();
            var last = enumerator.Current;
            for (; enumerator.MoveNext();)
            {
                action(last, enumerator.Current);
                last = enumerator.Current;
            }
            if (onLast != null)
            {
                onLast(last);
            }
        }

        [Obsolete("Use pairwise")]
        public static IEnumerable<TResult> Stitch<T, TResult>(
            this IEnumerable<T> self, Func<T, T, TResult> func, Func<T,TResult> onLast = null)
        {
            if (onLast != null)
            {
                var list = self.ToList();
                var res = list.Pairwise(func).ToList();
                res.Add(onLast(list.Last()));
                return res;
            }
            else
            {
                return self.Pairwise(func);
            }
        }
    }
}
