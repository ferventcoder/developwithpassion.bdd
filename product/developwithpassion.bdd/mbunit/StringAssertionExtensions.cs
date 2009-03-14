using System;
using MbUnit.Framework;

namespace developwithpassion.bdd.mbunit
{
    static public class StringAssertionExtensions
    {
        static public void should_be_equal_ignoring_case(this string item, string other)
        {
            Assert.AreEqual(other.ToLower(), item.ToLower());
        }

        static public void should_contain(this string item, string other)
        {
            StringAssert.Contains(item,other);
        }

        static public void should_not_be_null_or_empty(this string item){
            String.IsNullOrEmpty(item).should_be_false();
        }
    }
}