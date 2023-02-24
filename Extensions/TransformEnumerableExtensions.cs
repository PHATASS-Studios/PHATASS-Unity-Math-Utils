using System.Collections.Generic;

using Transform = UnityEngine.Transform;

namespace PHATASS.Utils.Extensions
{
	public static class TransformEnumerableExtensions
	{
		//returns an enumerators that iterates over every child and sub-child.
		//If includeRootTransforms == true, root transform will be included as first element before its children
		public static IEnumerable<Transform> EGetRecursiveChildEnumerator (this Transform transform, bool includeRootTransform)
		{
			return new PHATASS.Utils.Enumerables.TransformChildrenRecursiveEnumerable(transform, includeRootTransform);
		}
	}
}
