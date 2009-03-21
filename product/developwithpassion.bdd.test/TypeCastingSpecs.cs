using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using bdddoc.core;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.core.extensions;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdd.mbunit;

namespace developwithpassion.bdd.test
{
    public class TypeCastingSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (TypeCastingExtensions))]
        public class when_a_legitimate_downcast_is_made : concern
        {
            it should_not_fail = () =>
            {
                new List<int>().downcast_to<List<int>>();
            };
        }

        [Concern(typeof (TypeCastingExtensions))]
        public class when_determining_if_an_object_is_not_an_instance_of_a_specific_type : concern
        {
            it should_make_determination_based_on_whether_the_object_is_assignable_from_the_specific_type = () =>
            {
                new SqlConnection().is_not_a<IDbCommand>().should_be_true();
                new SqlConnection().is_not_a<IDbConnection>().should_be_false();
            };
        }
    }
}