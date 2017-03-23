using System;

namespace code.utility.containers
{
	public class TypeFactoryRegistry : IFindFactoriesForAType
	{
		IDetermineDependenciesOfType dependency_analyzer;

		public TypeFactoryRegistry(IDetermineDependenciesOfType dependency_analyzer)
		{
			this.dependency_analyzer = dependency_analyzer;
		}

		public object get_resolver_for_type(Type the_type)
		{
			var types_to_resolve = dependency_analyzer.get_dependencies_for_type(the_type);

			return new object();
		}
	}
}