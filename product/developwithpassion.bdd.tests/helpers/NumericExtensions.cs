namespace developwithpassion.bdd.tests.helpers
{
    static public class NumericExtensions
    {
        public static bool is_a_non_zero_multiple_of(this int item, int multiple) {
            return item%multiple == 0 && item !=0; 
        }

        public static bool is_odd(this int item){
            return item%2 != 0;
        }
    }
}