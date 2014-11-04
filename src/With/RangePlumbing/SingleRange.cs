using System;
using System.Collections;
using System.Collections.Generic;

namespace With.RangePlumbing
{

	internal class SingleRange:IEnumerable<Single>
	{
		private readonly Single @from;
		private readonly Single @to;
		private readonly Single @step;
		public SingleRange (Single @from, Single @to, Single step)
		{
			this.@from = @from;
			this.@to = @to;
			this.@step = @step;
		}
		public SingleRange (object @from, object @to, object step)
		{
			this.@from = (Single)@from;
			this.@to =  (Single)@to;
			this.@step =  (Single)@step;
		}

		public IEnumerator<Single> GetEnumerator ()
		{
			for (var i = @from; i<@to; i+=step) {
				yield return i;
			}
		}
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return this.GetEnumerator ();
		}
	}
}
