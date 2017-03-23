using developwithpassion.specifications;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.utility.containers
{
	[Subject(typeof(TypeFactoryRegistry))]
	public class TypeFactoryRegistrySpecs
	{
		public abstract class concern : use_engine<RhinoFakeEngine>.observe<IFindFactoriesForAType, TypeFactoryRegistry>
		{

		}

		public class when_fetching_factory_for_a_type : concern
		{
			Establish e = () =>
			{
				dependency_analyzer = depends.on<IDetermineDependenciesOfType>();
			};

			Because b = () =>
				sut.get_resolver_for_type(typeof(object));

			It determines_the_dependencies_for_that_type = () =>
				dependency_analyzer.should().received(x => x.get_dependencies_for_type(typeof(object)));

			static IDetermineDependenciesOfType dependency_analyzer;
		}
	}
}