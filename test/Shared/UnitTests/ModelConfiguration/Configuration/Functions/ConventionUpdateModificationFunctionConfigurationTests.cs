﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Data.Entity.ModelConfiguration.Configuration.Functions
{
    using System.Data.Entity.Utilities;
    using System.Linq;
    using Xunit;

    public class ConventionUpdateModificationFunctionConfigurationTests : ModificationFunctionConfigurationTTests
    {
        [Fact]
        public void HasName_should_set_name_on_underlying_configuration()
        {
            var configuration = new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity));

            configuration.HasName("Foo");

            Assert.Equal("Foo", configuration.Configuration.Name);
        }

        [Fact]
        public void HasName_when_schema_should_set_name_and_schema_on_underlying_configuration()
        {
            var configuration = new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity));

            configuration.HasName("Foo", "Bar");

            Assert.Equal("Foo", configuration.Configuration.Name);
            Assert.Equal("Bar", configuration.Configuration.Schema);
        }

        [Fact]
        public void Parameter_should_return_configuration_for_valid_property_expressions()
        {
            var configuration = new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity));

            Assert.Same(configuration, configuration.Parameter("Int", "Foo"));
            Assert.Same(configuration, configuration.Parameter(typeof(Entity).GetDeclaredProperty("String"), "Foo"));
        }

        [Fact]
        public void Parameter_should_set_parameter_name_for_valid_property_expressions()
        {
            Assert.Equal(
                "Foo",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Parameter("Int", "Foo").Configuration.ParameterNames.Single().Item1);

            Assert.Equal(
                "Foo",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Parameter("Pint", "Foo").Configuration.ParameterNames.Single().Item1);

            Assert.Equal(
                "Foo",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Parameter(typeof(Entity).GetDeclaredProperty("String"), "Foo").Configuration.ParameterNames.Single().Item1);
        }

        [Fact]
        public void Parameter_should_return_configuration_for_valid_property_expressions_when_original_values()
        {
            var configuration = new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity));

            Assert.Same(configuration, configuration.Parameter("Int", "Foo", "Bar"));
            Assert.Same(configuration, configuration.Parameter(typeof(Entity).GetDeclaredProperty("String"), "Foo", "Bar"));
        }

        [Fact]
        public void Parameter_should_set_parameter_name_for_valid_property_expressions_when_original_values()
        {
            Assert.Equal(
                "Bar",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Parameter("Int", "Foo", "Bar").Configuration.ParameterNames.Single().Item2);

            Assert.Equal(
                "Bar",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Parameter("Pint", "Foo", "Bar").Configuration.ParameterNames.Single().Item2);

            Assert.Equal(
                "Bar",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Parameter(typeof(Entity).GetDeclaredProperty("String"), "Foo", "Bar").Configuration.ParameterNames.Single().Item2);
        }

        [Fact]
        public void Result_should_return_configuration_for_valid_property_expressions()
        {
            var configuration = new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity));

            Assert.Same(configuration, configuration.Result("Int", "Foo"));
            Assert.Same(configuration, configuration.Result(typeof(Entity).GetDeclaredProperty("String"), "Foo"));
        }

        [Fact]
        public void Result_should_set_column_name_for_valid_property_expressions()
        {
            Assert.Equal(
                "Foo",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Result("Int", "Foo").Configuration.ResultBindings.Single().Value);

            Assert.Equal(
                "Foo",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Result("Pint", "Foo").Configuration.ResultBindings.Single().Value);

            Assert.Equal(
                "Foo",
                new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity))
                    .Result(typeof(Entity).GetDeclaredProperty("String"), "Foo").Configuration.ResultBindings.Single().Value);
        }

        [Fact]
        public void Parameter_is_no_op_when_not_found()
        {
            var configuration = new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity));

            Assert.Same(configuration, configuration.Parameter("Int1", "Foo"));
            Assert.Same(configuration, configuration.Parameter(typeof(Entity).GetDeclaredProperty("String1"), "Foo"));
        }

        [Fact]
        public void RowsAffectedParameter_should_set_column_name()
        {
            var configuration = new ConventionUpdateModificationStoredProcedureConfiguration(typeof(Entity));

            configuration.RowsAffectedParameter("Foo");

            Assert.Equal("Foo", configuration.Configuration.RowsAffectedParameterName);
        }
    }
}
