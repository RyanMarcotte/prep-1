using System;

namespace code.utility.matching
{
	public static class Sort<Item>
	{
		public static ICompareTwoItems<Item> by_descending<ItemProperty>(
			IGetTheValueOfAProperty<Item, ItemProperty> get_the_value_of_a_property)
			where ItemProperty : IComparable<ItemProperty>
		{
			return (item1, item2) => -get_the_value_of_a_property(item1).CompareTo(get_the_value_of_a_property(item2));
		}

		public static ICompareTwoItems<Item> by_ascending<ItemProperty>(
			IGetTheValueOfAProperty<Item, ItemProperty> get_the_value_of_a_property)
			where ItemProperty : IComparable<ItemProperty>
		{
			return (item1, item2) => get_the_value_of_a_property(item1).CompareTo(get_the_value_of_a_property(item2));
		}
	}
}