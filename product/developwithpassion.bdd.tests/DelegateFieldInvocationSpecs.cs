using System;
using bdddoc.core;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.core.commands;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdd.mbunit;

namespace developwithpassion.bdd.tests
{
    public class DelegateFieldInvocationSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ICommand,DelegateFieldInvocation> {}

        [Concern(typeof (DelegateFieldInvocation))]
        public class when_run_with_a_specified_delegate_type : concern
        {
            context c = () =>
            {
                target = new SomeClassWithDelegateFields();
                target.reset();

                delegate_type_to_run = typeof (because);
            };

            because b = () => sut.run();

            it should_invoke_all_of_the_matching_delegate_fields_in_the_target_type_against_the_target_instance = () =>
            {
                SomeClassWithDelegateFields.because_block_invocation_count.should_be_equal_to(2);
                SomeClassWithDelegateFields.after_each_observation_block_invocation_count.should_be_equal_to(0);
                SomeClassWithDelegateFields.context_block_invocation_count.should_be_equal_to(0);
            };

            public override ICommand create_sut()
            {
                return new DelegateFieldInvocation(delegate_type_to_run, target, target.GetType());
            }

            static Type delegate_type_to_run;
            static SomeClassWithDelegateFields target;
        }


        public class SomeClassWithDelegateFields
        {
            public void reset()
            {
                because_block_invocation_count = 0;
                after_each_observation_block_invocation_count = 0;
                context_block_invocation_count = 0;
            }

            because b = () =>
            {
                because_block_invocation_count++;
            };

            because b2 = () =>
            {
                because_block_invocation_count++;
            };

            context c = () =>
            {
                context_block_invocation_count ++;
            };

            context c2 = () =>
            {
                context_block_invocation_count ++;
            };

            after_each_observation a = () =>
            {
                after_each_observation_block_invocation_count++;
            };

            after_each_observation a2 = () =>
            {
                after_each_observation_block_invocation_count++;
            };

            static public int because_block_invocation_count;
            static public int after_each_observation_block_invocation_count;
            static public int context_block_invocation_count;
        }
    }
}