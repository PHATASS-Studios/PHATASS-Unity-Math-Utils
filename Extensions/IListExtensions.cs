using System.Collections;
using System.Collections.Generic;


namespace PHATASS.Utils.Extensions
{
	using Random = UnityEngine.Random;
	
	public static class IListExtensions
	{
	//Search methods
		// Search backwards from the end of an IList<T> and return first non-null object
		public static T EMGetLastNonNull<T> (this IList<T> list)
		{
			for (int i = list.Count-1; i >= 0; i--)
			{ if (list[i] != null) return list[i]; }
			return default(T);
		}
	//ENDOF Search methods


	//Casting methods
		// Casts all the elements of IList<TIn> into a new Array<TOut>
		//	Any element that doesn't properly cast as TOut is replaced by a null entry
		public static TOut[] EMListCastToArray <TIn, TOut> (this IList<TIn> list)
			where TOut : class
		{
			TOut[] array = new TOut[list.Count];
			for (int i = 0, iLimit = list.Count; i < iLimit; i++)
			{
				array[i] = (list[i] as TOut);
			}
			return array;
		}

		// Casts all the elements of IList<TIn> into a new List<TOut>
		//	Any element that doesn't properly cast as TOut is replaced by a null entry
		public static List<TOut> EMListCastToList <TIn, TOut> (this IList<TIn> list)
			where TOut : class
		{
			//[TO-DO] this process could be made more memory-efficient by creating the new list
				//from a casted enumerator instead of a pre-casted array
			return new List<TOut>(list.EMListCastToArray<TIn, TOut>());
		}
	//ENDOF Casting methods

	//Randomization methods
		// Returns a random item within this list
		//  IList<T> generic version
		public static T ERandomElement <T> (this IList<T> list)
		{
			if (list.Count == 0) { return default(T); }
			return list[Random.Range(0, list.Count)];
		}

		//  IList version
		public static object ERandomElement (this IList list)
		{
			if (list.Count == 0) { return null; }
			return list[Random.Range(0, list.Count)];
		}
	//ENDOF Randomization methods
	}
}