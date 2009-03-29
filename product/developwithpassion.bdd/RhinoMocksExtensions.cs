using System;
using Rhino.Mocks;

namespace developwithpassion.bdd
{
    static public class RhinoMocksExtensions
    {
        static public VoidMethodCallOccurance<T> was_told_to<T>(this T mock, Action<T> item)
        {
            return received(mock, item);
        }

        static public void was_never_told_to<T>(this T mock, Action<T> item)
        {
            never_received(mock, item);
        }

        static public VoidMethodCallOccurance<T> received<T>(this T mock, Action<T> item)
        {
            return new VoidMethodCallOccurance<T>(mock, item);
        }

        static public void never_received<T>(this T mock, Action<T> item)
        {
            mock.AssertWasNotCalled(item);
        }
    }
}