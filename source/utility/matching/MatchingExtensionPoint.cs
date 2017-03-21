namespace code.utility.matching
{
  public class MatchingExtensionPoint<ItemToMatch, Property>
  {
    public PropertyAccessor<ItemToMatch, Property> accessor { get;}

    public MatchingExtensionPoint(PropertyAccessor<ItemToMatch, Property> accessor)
    {
      this.accessor = accessor;
    }

	  public NegatedMatchingExtensionPoint<ItemToMatch, Property> not => new NegatedMatchingExtensionPoint<ItemToMatch, Property>(accessor);
  }
}