using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdd.tests.helpers;
using developwithpassion.bdd.mbunit;

namespace developwithpassion.bdd.tests
{
    public class EnumerableAssertionExtensionsSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        public class when_performing_enumerable_assertions_using_bdd_extensions_methods : concern
        {
            context c = () =>
            {
                the_numbers_1_to_10_in_order = Enumerable.Range(1, 10);
                multiples_of_10_upto_100 = Enumerable.Range(1, 100).Where(number => number.is_a_non_zero_multiple_of(10));
            };

            static IEnumerable<int> generate_set_of_numbers(int number_of_numbers, Action traversal_action)
            {
                foreach (var number in Enumerable.Range(1, number_of_numbers))
                {
                    yield return number;
                    traversal_action();
                }
            }

            it should_be_able_to_force_the_traversal_of_an_enumerable = () =>
            {
                var iterated_the_enumerable = false;

                var numbers = generate_set_of_numbers(100, () => iterated_the_enumerable = true);
                iterated_the_enumerable.should_be_false();

                numbers.force_traversal();
                iterated_the_enumerable.should_be_true();
            };

            it should_be_able_to_assert_that_an_enumerable_contains_an_item_matching_a_condition = () =>
            {
                multiples_of_10_upto_100.should_contain_item_matching(number => number == 50);
            };

            it should_be_able_to_assert_that_an_enumerable_does_not_contain_an_item_matching_a_condition = () =>
            {
                multiples_of_10_upto_100.should_not_contain_item_matching(number => number.is_odd());
            };

            it should_be_able_to_assert_that_an_enumerable_contains_a_certain_item = () =>
            {
                multiples_of_10_upto_100.should_contain(50);
            };

            it should_be_able_to_assert_that_an_enumerable_contains_a_set_of_items = () =>
            {
                multiples_of_10_upto_100.should_contain(10,20,30,40,80);
            };

            it should_be_able_to_assert_that_all_items_in_an_enumerable_satisfy_a_condition = () =>
            {
                multiples_of_10_upto_100.should_all_satisfy(number => number.is_a_non_zero_multiple_of(10));
            };

            it should_be_able_to_assert_that_an_enumerable_does_not_contain_a_set_of_items = () =>
            {
                multiples_of_10_upto_100.should_not_contain(1, 2, 3, 15, 45, 64);
            };

            it should_be_able_to_assert_that_an_enumerable_only_contains_a_certain_set_of_items = () =>
            {
                the_numbers_1_to_10_in_order.should_only_contain(1,2,3,4,5,6,7,8,9,10);
            };

            it should_be_able_to_assert_that_an_enumerable_only_contains_a_certian_set_of_items_and_they_are_in_a_particular_order = () =>
            {
                multiples_of_10_upto_100.should_only_contain_in_order(10,20,30,40,50,60,70,80,90,100);
            };

            static IEnumerable<int> the_numbers_1_to_10_in_order;
            static IEnumerable<int> multiples_of_10_upto_100;
        }
    }
}
