using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;

namespace developwithpassion.bdd.mbunit
{
    public class ComparisonAssertionExtensionsSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        public class when_performing_comparison_assertions_with_bdd_extension_methods : concern
        {
            it should_be_able_to_assert_that_a_comparable_item_is_greater_than_another_comparable_item = () =>
            {
                2.should_be_greater_than(1);
            };

            it should_be_able_to_assert_that_a_comparable_item_is_less_than_another_comparable_item = () =>
            {
                1.should_be_less_than(2);
            };

            it should_be_able_to_assert_that_a_comparable_is_less_than_or_equal_to_another_comparable = () => 
            {
                1.should_be_less_than_or_equal_to(2); 
                2.should_be_less_than_or_equal_to(2);
            };

            it should_be_able_to_assert_that_a_comparable_is_greater_than_or_equal_to_another_comparable = () => 
            {
                2.should_be_greater_than_or_equal_to(2); 
                3.should_be_greater_than_or_equal_to(2);
            };

            it should_be_able_to_assert_that_an_item_is_not_equal_to_an_unequal_item = () => 
            {
                 1.should_not_be_equal_to(2); 
            };

            it should_be_able_to_assert_that_an_item_is_equal_to_an_equal_item = () => 
            {
                2.should_be_equal_to(2);
            };

            it should_be_able_to_assert_that_an_integer_is_zero = () => 
            {
                0.should_be_zero(); 
            };

            it should_be_able_to_assert_that_a_long_is_zero = () => 
            {
                0L.should_be_zero(); 
            };
        }
    }
}