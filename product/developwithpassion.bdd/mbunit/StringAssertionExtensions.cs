using System;
using MbUnit.Framework;

namespace developwithpassion.bdd.mbunit
{
    static public class StringAssertionExtensions
    {
        static public void should_be_equal_ignoring_case(this string result, string expected)
        {
            StringAssert.AreEqualIgnoreCase(expected, result);
        }

        static public void should_contain(this string item, string string_to_contain)
        {
            StringAssert.Contains(item, string_to_contain);
        }

        static public void should_not_be_null_or_empty(this string item)
        {
            String.IsNullOrEmpty(item).should_be_false();
        }
    }
}