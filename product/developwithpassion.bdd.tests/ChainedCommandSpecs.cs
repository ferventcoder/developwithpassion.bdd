using bdddoc.core;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.core.commands;
using developwithpassion.bdd.mbunit.standard.observations;

namespace developwithpassion.bdd.tests
{
    public class ChainedCommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ICommand, ChainedCommand>
        {
            static protected ICommand command_one;
            static protected ICommand command_two;

            context c = () =>
            {
                command_one = an<ICommand>();
                command_two = an<ICommand>();
            };

            public override ICommand create_sut()
            {
                return new ChainedCommand(command_one, command_two);
            }
        }

        [Concern(typeof (ChainedCommand))]
        public class when_it_runs : concern
        {
            because b = () => sut.run();

            it should_run_each_command_it_is_composed_with = () =>
            {
                command_one.received(x => x.run());
                command_two.received(x => x.run());
            };
        }
    }
}