using System;
using System.Collections.Generic;
using System.Data;
using bdddoc.core;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard;
using developwithpassion.bdd.mbunit.standard.observations;
using MbUnit.Framework;
using Rhino.Mocks;

namespace developwithpassion.bdd.tests
{
    public class observations_for_an_instance_sut_specs
    {
        [Observations]
        public abstract class concern
        {
            protected SampleTestWithAnSut sut;

            [SetUp]
            public void setup()
            {
                sut = new SampleTestWithAnSut();
                establish_context();
                because();
            }

            protected virtual void establish_context() {}
            protected abstract void because();
        }

        [Concern(typeof (observations_for_an_instance_sut<,>))]
        public class when_creating_an_instance_of_the_sut_and_no_dependencies_have_been_provided : concern
        {
            AClassWithDependences result;

            protected override void establish_context()
            {
                SampleTestWithAnSut.dependencies = new Dictionary<Type, object>();
            }

            protected override void because()
            {
                result = sut.create_sut();
            }


            [Observation]
            public void should_create_the_sut_and_automatically_mock_out_dependencies_that_can_be_mocked()
            {
                result.should_not_be_null();
                result.connection.should_be_an_instance_of<IDbConnection>();
                result.command.should_be_an_instance_of<IDbCommand>();
            }
        }

        [Concern(typeof (observations_for_an_instance_sut<,>))]
        public class when_creating_an_instance_of_the_sut_and_dependencies_have_been_provided : concern
        {
            AClassWithDependences result;
            IDbConnection connection;
            IDbCommand command;

            protected override void establish_context()
            {
                SampleTestWithAnSut.dependencies = new Dictionary<Type, object>();
                connection = MockRepository.GenerateMock<IDbConnection>();
                command = MockRepository.GenerateMock<IDbCommand>();
                SampleTestWithAnSut.dependencies.Add(typeof (IDbConnection), connection);
                SampleTestWithAnSut.dependencies.Add(typeof (IDbCommand), command);
            }

            protected override void because()
            {
                result = sut.create_sut();
            }


            [Observation]
            public void should_create_the_sut_using_the_dependencies_that_were_provided_by_the_client()
            {
                result.should_not_be_null();
                result.connection.should_be_equal_to(connection);
                result.command.should_be_equal_to(command);
            }
        }

        public class SampleTestWithAnSut : observations_for_an_instance_sut<AClassWithDependences, AClassWithDependences> {}



        public class AClassWithDependences
        {
            public IDbCommand command { get; private set; }
            public IDbConnection connection { get; private set; }

            public AClassWithDependences(IDbCommand command, IDbConnection connection)
            {
                this.command = command;
                this.connection = connection;
            }

            public void open_the_connection()
            {
                connection.Open();
            }

            public void update_the_commands_transaction(IDbTransaction transaction)
            {
                command.Transaction = transaction;
            }
        }
    }
}