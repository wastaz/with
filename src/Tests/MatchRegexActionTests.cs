using System;
using With;
using NUnit.Framework;
namespace Tests
{	

	[TestFixture]
	public class MatchRegexActionTests
	{
		private string DoMatch(string v){
			string retval = null;
			Switch.Match<string> (v)
				.Case ("1", () => retval= "One!")
				.Regex ("[A-Z]{1}[a-z]{2}\\d{1,}", p =>retval= "Happ!")
				.Case (i=>i=="42",(i)=>retval="Meaning of life")
				.Case (i=>i=="52",()=>retval="Some other number")
				.Else (_ => retval="Ain't special");
			return retval;
		}

		[Test]
		public void Test_one(){
			Assert.That (DoMatch ("1"), Is.EqualTo ("One!"));
		}
		[Test]
		public void Test_complicated(){
			Assert.That (DoMatch ("Rio1"), Is.EqualTo ("Happ!"));
		}

		[Test]
		public void Test_other(){
			Assert.That (DoMatch ("200"), Is.EqualTo ("Ain't special"));
			Assert.That (DoMatch ("29"), Is.EqualTo ("Ain't special"));
		}
		[Test]
		public void Test_meaning_of_life(){
			Assert.That (DoMatch ("42"), Is.EqualTo ("Meaning of life"));
		}

	}
}
