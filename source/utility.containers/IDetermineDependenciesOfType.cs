using System;
using System.Collections.Generic;

namespace code.utility.containers
{
	public interface IDetermineDependenciesOfType
	{
		IEnumerable<Type> get_dependencies_for_type(Type type);
	}
}