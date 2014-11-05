﻿using System;
using With;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
	[TestFixture]
	public class RangeTests
	{
		[Test]
		public void New_Int_range()
		{
			Assert.That (new Range<int> (0,2).ToArray(), Is.EquivalentTo (new []{ 0, 1, 2 }));
		}
		[Test]
		public void Int_range()
		{
			Assert.That ( 0.To( 2).ToArray(), Is.EquivalentTo (new []{ 0, 1, 2 }));
		}
		[Test]
		public void Int_range_with_step()
		{
			Assert.That ( 0.To( 4).Step(2).ToArray(), Is.EquivalentTo (new []{ 0, 2, 4 }));
		}
		[Test]
		public void Int_range_has()
		{
			var range = 0.To (4).Step (2);
			Assert.That (range.Contain(2), Is.True);
			Assert.That (range.Contain(0), Is.True);
			Assert.That (range.Contain(4), Is.True);

			Assert.That (range.Contain(-1), Is.False);
			Assert.That (range.Contain(1), Is.False);
			Assert.That (range.Contain(5), Is.False);
		}
		[Test]
		public void New_Long_range()
		{
			Assert.That (new Range<long> (0,2).ToArray(), Is.EquivalentTo (new []{ 0, 1, 2 }));
		}
		[Test]
		public void Long_range()
		{
			Assert.That ( 0L.To( 2L).ToArray(), Is.EquivalentTo (new []{ 0L, 1L, 2L }));
		}
		[Test]
		public void Long_range_with_step()
		{
			Assert.That ( 0L.To( 4L).Step(2).ToArray(), Is.EquivalentTo (new []{ 0L, 2L, 4L }));
		}

		[Test]
		public void Long_range_has()
		{
			var range = 0L.To (4L).Step (2L);
			Assert.That (range.Contain(2), Is.True);
			Assert.That (range.Contain(0), Is.True);
			Assert.That (range.Contain(4), Is.True);

			Assert.That (range.Contain(-1), Is.False);
			Assert.That (range.Contain(1), Is.False);
			Assert.That (range.Contain(5), Is.False);
		}

		[Test]
		public void New_Float_range()
		{
			Assert.That (new Range<float> (0.1F,2.1F).ToArray(), Is.EquivalentTo (new []{ 0.1F, 1.1F, 2.1F }));
		}
		[Test]
		public void Float_range()
		{
			Assert.That (0.1F.To(2.1F).ToArray(), Is.EquivalentTo (new []{ 0.1F, 1.1F, 2.1F }));
		}
		[Test]
		public void Float_range_with_step()
		{
			Assert.That (0.1F.To(4.1F).Step(2).ToArray(), Is.EquivalentTo (new []{ 0.1F, 2.1F, 4.1F }));
		}

		[Test,Ignore("Doesnt work")]
		public void Float_range_has()
		{
			var range = 0.1F.To(4.1F).Step (2F);
			Assert.That (range.Contain(2.1F), Is.True);
			Assert.That (range.Contain(0.1F), Is.True);
			Assert.That (range.Contain(4.1F), Is.True);

			Assert.That (range.Contain(-1.1F), Is.False);
			Assert.That (range.Contain(1.1F), Is.False);
			Assert.That (range.Contain(5.1F), Is.False);

			Assert.That (range.Contain(2F), Is.False);
			Assert.That (range.Contain(0F), Is.False);
			Assert.That (range.Contain(4F), Is.False);
		}

		[Test]
		public void New_Decimal_range()
		{
			Assert.That (new Range<Decimal> (0.1m,2.1m).ToArray(), Is.EquivalentTo (new []{ 0.1m, 1.1m, 2.1m }));
		}
		[Test]
		public void Decimal_range()
		{
			Assert.That (0.1m.To(2.1m).ToArray(), Is.EquivalentTo (new []{ 0.1m, 1.1m, 2.1m }));
		}
		[Test]
		public void Decimal_range_with_step()
		{
			Assert.That (0.1m.To(4.1m).Step(2).ToArray(), Is.EquivalentTo (new []{ 0.1m, 2.1m, 4.1m }));
		}
		[Test]
		public void Decimal_range_has()
		{
			var range = 0.1m.To(4.1m).Step(2m);
			Assert.That (range.Contain(2.1m), Is.True);
			Assert.That (range.Contain(0.1m), Is.True);
			Assert.That (range.Contain(4.1m), Is.True);

			Assert.That (range.Contain(-1.1m), Is.False);
			Assert.That (range.Contain(1.1m), Is.False);
			Assert.That (range.Contain(5.1m), Is.False);

			Assert.That (range.Contain(2m), Is.False);
			Assert.That (range.Contain(0m), Is.False);
			Assert.That (range.Contain(4m), Is.False);
		}
	}
}

