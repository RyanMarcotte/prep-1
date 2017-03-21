using System;

namespace code.utility.matching
{
	public static class NegatedMatchingExtensions
	{
		public static IMatchA<Item> equal_to<Item, Property>(this NegatedMatchingExtensionPoint<Item, Property> extension_point, Property property)
		{
			return not_create(extension_point, item => extension_point.accessor(item).Equals(property));
		}

		public static IMatchA<Item> not_create<Item, Property>(this NegatedMatchingExtensionPoint<Item, Property> extension_point, Criteria<Item> condition)
		{
			return new NegatingMatch<Item>(new CriteriaMatch<Item>(condition));
		}

		public static IMatchA<Item> not_create<Item, Property>(this NegatedMatchingExtensionPoint<Item, Property> extension_point, IMatchA<Property> value_matcher)
		{
			return new PropertyMatch<Item, Property>(extension_point.accessor, new NegatingMatch<Property>(value_matcher));
		}
	}

  public static class MatchingExtensions
  {
		

		public static IMatchA<Item> equal_to<Item,Property>(this MatchingExtensionPoint<Item,Property> extension_point, Property property)
    {
      return create(extension_point, item => extension_point.accessor(item).Equals(property));
    }

    public static IMatchA<Item> equal_to_any<Item,Property>(this MatchingExtensionPoint<Item,Property> extension_point, params Property[] values)
    {
      return create(extension_point, new EqualToAny<Property>(values));
    }

    public static IMatchA<Item> not_equal_to<Item,Property>(this MatchingExtensionPoint<Item,Property> extension_point, Property value)
    {
      return equal_to(extension_point, value).not();
    }

    public static IMatchA<Item> greater_than<Item,Property>(this MatchingExtensionPoint<Item,Property> extension_point, Property value) where Property : IComparable<Property>
    {
      return create(extension_point, new GreaterThan<Property>(value));
    }

    public static IMatchA<Item> between<Item,Property>(this MatchingExtensionPoint<Item,Property> extension_point, Property start, Property end) where Property : IComparable<Property>
    {
      return create(extension_point, new Between<Property>(start, end ));
    }

    public static IMatchA<Item> create<Item,Property>(this MatchingExtensionPoint<Item,Property> extension_point, Criteria<Item> condition)
    {
      return new CriteriaMatch<Item>(condition);
    }

    public static IMatchA<Item> create<Item,Property>(this MatchingExtensionPoint<Item,Property> extension_point, IMatchA<Property> value_matcher)
    {
      return new PropertyMatch<Item,Property>(extension_point.accessor, value_matcher);
    }
  }
}
