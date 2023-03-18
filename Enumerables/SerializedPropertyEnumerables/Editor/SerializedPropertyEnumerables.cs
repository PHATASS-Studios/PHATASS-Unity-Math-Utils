using System.Collections.Generic;
using System.Collections;

using SerializedProperty = UnityEditor.SerializedProperty;

namespace PHATASS.Utils.Extensions.Editor
{
	public static class SerializedPropertyEnumerables
	{
//extension methods
	// Array/list conversion methods
		// Transfers all elements from an array/list property to a new array/list
		public static T[] EToValueArray<T> (this SerializedProperty property)
		{ return property.EToValueList<T>().ToArray(); }

		public static List<T> EToValueList<T> (this SerializedProperty property)
		{
			return new List<T>(property.EToValueEnumerable());
		}
	//ENDOF Array/list conversion methods

	// Enumerables
		// Enumerable that iterates over every member or array element values
		public static IEnumerable EToValueEnumerable (this SerializedProperty property)
		{
			return new SerializedPropertyValueEnumerable(property);
		}

		//public static
	//ENDOF Enumerables
//ENDOF extension methods

	}
}