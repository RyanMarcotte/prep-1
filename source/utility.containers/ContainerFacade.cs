using System;

namespace code.utility.containers
{
    public class ContainerFacade : IFetchDependencies
    {
	    IFindFactoriesForAType factory_finder;

	    public ContainerFacade(IFindFactoriesForAType factory_finder)
	    {
		    this.factory_finder = factory_finder;
	    }

	    public ItemToFetch an<ItemToFetch>()
	    {
		    return (ItemToFetch)factory_finder.get_resolver_for_type(typeof(ItemToFetch));
	    }
    }
}