using System;

namespace With
{
	public static class CommonExtensions
	{
		public static T Tap<T>(this T that, Action<T> tapaction)
		{
			tapaction(that);
			return that;
		}

        public static Out Chain<In, Out>(this In objectInChain, Func<In,Out> chain) 
        {
            return chain(objectInChain);
        }
	}
}

