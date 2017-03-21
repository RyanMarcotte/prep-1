namespace code.utility.matching
{
	public class NegatedMatchingExtensionPoint<ItemToMatch, Property>
	{
		public PropertyAccessor<ItemToMatch, Property> accessor { get; }

		public NegatedMatchingExtensionPoint(PropertyAccessor<ItemToMatch, Property> accessor)
		{
			this.accessor = accessor;
		}
	}
}