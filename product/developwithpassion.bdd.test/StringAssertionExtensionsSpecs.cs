using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;

namespace developwithpassion.bdd.test
{
    public class StringAssertionExtensionsSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        public class when_performing_string_assertions_using_bdd_style_extension_methods : concern
        {
            it should_be_able_to_assert_that_2_strings_are_equal_irrespective_of_case = () =>
            {
                "blah".should_be_equal_ignoring_case("blah");
                "BLah".should_be_equal_ignoring_case("blah");
            };

            it should_be_able_to_assert_that_string_is_not_null_or_empty = () =>
            {
                "blah".should_not_be_null_or_empty();
            };

            it should_be_able_to_assert_that_a_string_contains_another_string = () => 
            {
                "blah".should_contain("bl");
            };
        }
    }
}