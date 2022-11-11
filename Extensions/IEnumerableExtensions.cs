using System.Collections;
using System.Collections.Generic;

namespace PHATASS.Utils.Extensions
{
	public static class IEnumerableExtensions
	{
	//Validation methods
		//Checks that this enumerato both exists (is not null) and contains at least one non-null element
		//Returns true only if all of the following are true
		// > enumerable is NOT NULL
		// > enumerable contains more than 0 elements
		// > enumerable contains at least one non-null element

		//	IEnumerable<T> generic version
		public static bool EMExistsAndContainsAnything <T> (this IEnumerable<T> enumerable)
		{ return (enumerable as IEnumerable).EMExistsAndContainsAnything(); }
		//	IEnumerable version
		public static bool EMExistsAndContainsAnything (this IEnumerable enumerable)
		{
			if (enumerable == null) { return false; }
			foreach (object element in enumerable)
			{ if (element != null) { return true; }}
			return false;
		}
	//ENDOF Validation methods

	}
}