using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

namespace PHATASS.Utils.Extensions
{
	public static class IListExtensions
	{
	//ERandomElement
	// Returns a random item within this list
		//IList<T> version
		public static T ERandomElement <T> (this IList<T> list)
		{
			if (list.Count == 0) { return default(T); }
			return list[Random.Range(0, list.Count)];
		}

		//IList version
		public static object ERandomElement (this IList list)
		{
			if (list.Count == 0) { return null; }
			return list[Random.Range(0, list.Count)];
		}
	//ENDOF ERandomElement
	}
}