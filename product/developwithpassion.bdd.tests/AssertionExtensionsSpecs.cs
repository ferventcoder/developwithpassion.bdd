using System;
using System.Data;
using System.Data.SqlClient;
using bdddoc.core;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;

namespace developwithpassion.bdd.tests
{
    public class AssertionExtensionsSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (AssertionExtensions))]
        public class when_performing_assertions_using_bdd_extension_methods : concern
        {
            it should_be_able_to_determine_if_something_is_null = () =>
            {
                object item = null;
                item.should_be_null();
            };

            it should_be_able_to_determine_if_something_is_not_null = () =>
            {
                new object().should_not_be_null();
            };

            it should_be_able_to_determine_if_something_is_true = () =>
            {
                true.should_be_true();
            };

            it should_be_able_to_determine_if_something_is_false = () =>
            {
                false.should_be_false();
            };

            it should_be_able_to_express_an_action_that_does_not_throw_an_exception = () =>
            {
                Action action = () => {};
                action.should_not_throw_any_exceptions();
            };

            it should_be_able_to_determine_whether_an_item_is_an_instance_of_a_type = () =>
            {
                new SqlConnection().should_be_an<IDbConnection>();
            };
        }
    }
}