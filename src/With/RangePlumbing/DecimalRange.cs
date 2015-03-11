using System;
using System.Collections;
using System.Collections.Generic;

namespace With.RangePlumbing
{
	internal class DecimalRange:IStep<Decimal>
	{
		private readonly Decimal @from;
		private readonly Decimal @to;
		private readonly Decimal @step;
		public DecimalRange (Decimal @from, Decimal @to, Decimal step)
		{
			this.@from = @from;
			this.@to = @to;
            this.@step = Math.Abs(@step);
		}
		internal DecimalRange (object @from, object @to, object step)
            :this((Decimal) @from,(Decimal)@to, (Decimal)@step)
		{
		}

		public IStep<Decimal> Step(Decimal step){
			return new DecimalRange (@from,@to,step);
		}

		public bool Contain (decimal value)
		{
            if (@from <= @to)
            {
                return @from <= value && value <= @to && (value - @from) % step == 0; 
            }
            return @to <= value && value <= @from && (value - @from) % step == 0;
		}

		public IEnumerator<Decimal> GetEnumerator ()
		{
            if (@from <= @to)
            {
                for (var i = @from; i <= @to; i += step)
                {
                    yield return i;
                }
            }
            for (var i = @from; i >= @to; i -= step)
            {
                yield return i;
            }
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return this.GetEnumerator ();
		}
	}

}
